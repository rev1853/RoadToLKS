package com.example.esemkashowroom

import android.content.Context
import android.content.Intent
import androidx.appcompat.app.AppCompatActivity
import android.os.Bundle
import android.util.Log
import android.view.LayoutInflater
import android.view.View
import android.view.ViewGroup
import android.widget.Button
import android.widget.EditText
import android.widget.LinearLayout
import android.widget.TextView
import androidx.activity.result.ActivityResultLauncher
import androidx.activity.result.contract.ActivityResultContracts
import androidx.appcompat.widget.AppCompatButton
import androidx.recyclerview.widget.LinearLayoutManager
import androidx.recyclerview.widget.RecyclerView
import kotlinx.coroutines.Dispatchers
import kotlinx.coroutines.GlobalScope
import kotlinx.coroutines.launch
import org.json.JSONArray
import java.net.HttpURLConnection
import java.net.URL

class MainActivity : AppCompatActivity() {

    private lateinit var searchEditText: EditText
    private lateinit var searchButton: Button
    private lateinit var recyclerView: RecyclerView
    private lateinit var postAdapter: UserAdapter

    private var detailLauncher = registerForActivityResult(ActivityResultContracts.StartActivityForResult()) {
        if (it.resultCode == 200) {
            refresh()
        }
    }

    private fun refresh() {
        GlobalScope.launch(Dispatchers.IO){
            val url = URL("https://6597231a668d248edf22a0d3.mockapi.io/Cars")
            val conn = url.openConnection() as HttpURLConnection
            conn.requestMethod = "GET"

            val ambildata=conn.inputStream.bufferedReader().readLines().toString()
            Log.d("smk",ambildata)

            searchEditText = findViewById(R.id.search_et)
            searchButton = findViewById(R.id.search_btn)
            recyclerView = findViewById(R.id.list)

            searchButton.setOnClickListener {
                searchEditText.text.toString()

            }


            GlobalScope.launch(Dispatchers.Main){
                val user = JSONArray(ambildata).getJSONArray(0)
                val listview = findViewById<RecyclerView>(R.id.list)
                listview.adapter = UserAdapter(user, detailLauncher)
                listview.layoutManager = LinearLayoutManager(this@MainActivity)

//                postAdapter = UserAdapter(user)
//                recyclerView.layoutManager = LinearLayoutManager(this@MainActivity)
//                recyclerView.adapter = postAdapter



            }

        }
    }

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.activity_main)


        val create=findViewById<AppCompatButton>(R.id.create_btn)
        create.setOnClickListener {
            val inten = Intent(this,createData::class.java)
            startActivity(inten)
        }

        refresh()

    }
}




class UserAdapter(val users : JSONArray, var launcher: ActivityResultLauncher<Intent>) : RecyclerView.Adapter<UserAdapter.ViewHolder>() {
       class ViewHolder(itemView: View, val context: Context) : RecyclerView.ViewHolder(itemView){
           val Nama : TextView = itemView.findViewById(R.id.nama)
           val Brand : TextView = itemView.findViewById(R.id.brand)
           val detail : LinearLayout = itemView.findViewById(R.id.detail_user)


       }

       override fun onCreateViewHolder(parent: ViewGroup, viewType: Int): ViewHolder {
           val before = LayoutInflater.from(parent.context)
           val after = before.inflate(R.layout.user_list,parent,false)
           return ViewHolder(after,parent.context)
       }

       override fun getItemCount(): Int {
           return users.length()
       }

       override fun onBindViewHolder(holder: ViewHolder, position: Int) {
          val item = users.getJSONObject(position)
           holder.Nama.text = item.getString("name")
           holder.Brand.text = item.getString("brand")

           holder.detail.setOnClickListener {

               val inten = Intent(holder.context , detailData::class.java)
               inten.putExtra("data_mobil",item.toString())
               launcher.launch(inten)
           }
       }
   }








