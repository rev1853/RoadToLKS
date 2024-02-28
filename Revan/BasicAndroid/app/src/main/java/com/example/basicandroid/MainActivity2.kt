package com.example.basicandroid

import android.app.Activity
import android.content.Context
import android.content.Intent
import android.graphics.BitmapFactory
import androidx.appcompat.app.AppCompatActivity
import android.os.Bundle
import android.util.Log
import android.view.LayoutInflater
import android.view.View
import android.view.ViewGroup
import androidx.activity.result.contract.ActivityResultContracts
import androidx.core.content.res.ResourcesCompat
import androidx.recyclerview.widget.LinearLayoutManager
import androidx.recyclerview.widget.RecyclerView
import com.example.basicandroid.databinding.ActivityMain2Binding
import com.example.basicandroid.databinding.CartKofiBinding
import kotlinx.coroutines.CoroutineExceptionHandler
import kotlinx.coroutines.Dispatchers
import kotlinx.coroutines.GlobalScope
import kotlinx.coroutines.launch
import org.json.JSONArray
import org.json.JSONObject
import java.net.HttpURLConnection
import java.net.URL

class MainActivity2 : AppCompatActivity() {

    lateinit var binding: ActivityMain2Binding

    private var createKofiLauncher = registerForActivityResult(ActivityResultContracts.StartActivityForResult()) {
        if (it.resultCode == Activity.RESULT_OK) {
            refreshData()
        }
    }

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        binding = ActivityMain2Binding.inflate(this.layoutInflater)
        setContentView(binding.root)

        var userStr = this.getSharedPreferences("random", Context.MODE_PRIVATE).getString("user", "{}")
        var user = JSONObject(userStr)

        binding.welcomeTv.text = "Welcome, ${user.getString("firstName")}"

        binding.createBtn.setOnClickListener {
            createKofiLauncher.launch(Intent(this, MainActivity3::class.java))
        }

        refreshData()
    }

    fun refreshData() {
        GlobalScope.launch(Dispatchers.IO) {
            val coffeesStr = URL("https://65dc2aa13ea883a152929961.mockapi.io/coffees").openStream().bufferedReader().readText()
            val coffees = JSONArray(coffeesStr)

            runOnUiThread {
                class CustomVH(val binding: CartKofiBinding) : RecyclerView.ViewHolder(binding.root)

                var adapter = object : RecyclerView.Adapter<CustomVH>() {
                    override fun onCreateViewHolder(
                        parent: ViewGroup,
                        viewType: Int
                    ): CustomVH {
                        var binding = CartKofiBinding.inflate(LayoutInflater.from(parent.context), parent, false)
                        return CustomVH(binding)
                    }
                    override fun getItemCount(): Int = coffees.length()

                    override fun onBindViewHolder(holder: CustomVH, position: Int) {
                        val user = coffees.getJSONObject(position)
                        holder.binding.nameTv.text = user.getString("name")
                        holder.binding.ratingTv.text = user.getString("rating")

                        var imageUrl = user.getString("image")
                        var exception = CoroutineExceptionHandler { _, _ ->
                            holder.binding.imageIv.setImageDrawable(ResourcesCompat.getDrawable(this@MainActivity2.resources, R.drawable.default_img, this@MainActivity2.theme))
                        }

                        GlobalScope.launch(Dispatchers.IO + exception) {
                            val imageBitmap = BitmapFactory.decodeStream(URL(imageUrl).openStream())
                            runOnUiThread {
                                holder.binding.imageIv.setImageBitmap(imageBitmap)
                            }
                        }

                        holder.binding.root.setOnClickListener {
                            startActivity(Intent(this@MainActivity2, MainActivity4::class.java).apply {
                                putExtra("id", user.getString("id"))
                            })
                        }
                    }
                }

                binding.kofiRv.adapter = adapter
                binding.kofiRv.layoutManager = LinearLayoutManager(this@MainActivity2)
            }
        }
    }
}