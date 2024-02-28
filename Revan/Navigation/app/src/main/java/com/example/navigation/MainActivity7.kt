package com.example.navigation

import android.graphics.BitmapFactory
import androidx.appcompat.app.AppCompatActivity
import android.os.Bundle
import android.view.View
import android.view.ViewGroup
import android.widget.AdapterView
import android.widget.AdapterView.OnItemSelectedListener
import android.widget.ArrayAdapter
import android.widget.Toast
import com.example.navigation.databinding.ActivityMain6Binding
import com.example.navigation.databinding.ActivityMain7Binding
import com.example.navigation.databinding.DropdownLayoutBinding
import com.example.navigation.databinding.SpinnerLayoutBinding
import kotlinx.coroutines.Dispatchers
import kotlinx.coroutines.GlobalScope
import kotlinx.coroutines.launch
import org.json.JSONArray
import org.json.JSONObject
import java.net.URL

class MainActivity7 : AppCompatActivity() {
    lateinit var binding: ActivityMain7Binding
    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        binding = ActivityMain7Binding.inflate(layoutInflater)
        setContentView(binding.root)

        binding.kofiSpn.onItemSelectedListener = object : OnItemSelectedListener {
            override fun onItemSelected(adapter: AdapterView<*>?, p1: View?, pos: Int, p3: Long) {
                val item = adapter?.getItemAtPosition(pos) as JSONObject?
                Toast.makeText(this@MainActivity7, item?.getString("id"),Toast.LENGTH_SHORT).show()
            }

            override fun onNothingSelected(p0: AdapterView<*>?) {
                TODO("Not yet implemented")
            }

        }

//        val adapter = ArrayAdapter(this, android.R.layout.simple_spinner_item, list)

        GlobalScope.launch(Dispatchers.IO) {
            val kofiStr = URL("https://65dc2aa13ea883a152929961.mockapi.io/coffees").openStream().bufferedReader().readText()
            val banyakKofi = JSONArray(kofiStr)

            runOnUiThread {
                val adapter = object : ArrayAdapter<JSONObject>(this@MainActivity7, android.R.layout.simple_spinner_item) {
                    override fun getCount(): Int = banyakKofi.length()

                    override fun getItem(position: Int): JSONObject? {
                        return banyakKofi.getJSONObject(position)
                    }

                    override fun getView(
                        position: Int,
                        convertView: View?,
                        parent: ViewGroup
                    ): View {
                        val binding = SpinnerLayoutBinding.inflate(layoutInflater, parent, false)
                        val item = getItem(position)
                        binding.nameTv.text = item?.getString("name")
                        binding.ratingTv.text = item?.getString("rating")

                        return binding.root
                    }

                    override fun getDropDownView(
                        position: Int,
                        convertView: View?,
                        parent: ViewGroup
                    ): View {
                        val binding = DropdownLayoutBinding.inflate(layoutInflater, parent, false)
                        val item = getItem(position)
                        binding.nameTv.text = item?.getString("name")
                        binding.ratingTv.text = item?.getString("rating")

                        GlobalScope.launch(Dispatchers.IO) {
                            val bitmap = BitmapFactory.decodeStream( URL(item?.getString("image")).openStream())

                            runOnUiThread {
                                binding.kofiIv.setImageBitmap(bitmap)
                            }
                        }

                        return binding.root
                    }
                }

                binding.kofiSpn.adapter = adapter
            }
        }
    }
}