package com.example.normallevel

import androidx.appcompat.app.AppCompatActivity
import android.os.Bundle
import android.util.Log
import android.view.LayoutInflater
import android.view.View
import android.view.ViewGroup
import android.widget.CheckBox
import android.widget.TextView
import androidx.appcompat.view.menu.MenuView.ItemView
import androidx.recyclerview.widget.LinearLayoutManager
import androidx.recyclerview.widget.RecyclerView
import kotlinx.coroutines.Dispatchers
import kotlinx.coroutines.GlobalScope
import kotlinx.coroutines.launch
import org.json.JSONArray
import java.net.HttpURLConnection
import java.net.URL

class RecyclerViewCustom : AppCompatActivity() {
    private lateinit var recyclerView: RecyclerView

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.activity_recycler_view_custom)

        recyclerView = findViewById(R.id.recyview)

        Log.d("Panggil" ,"Load")
        loadData()
    }

    private fun loadData(){
        Log.d("Panggil" ,"Load data")
        GlobalScope.launch(Dispatchers.IO) {
            try {
                val url = URL("https://jsonplaceholder.typicode.com/todos")
                val conn = url.openConnection() as HttpURLConnection

                conn.requestMethod = "GET"

                val result = conn.inputStream.bufferedReader().readText()

                val json = JSONArray(result)

                GlobalScope.launch(Dispatchers.Main) {
                if (::recyclerView.isInitialized){
                        recyclerView.layoutManager = LinearLayoutManager(applicationContext)
                        recyclerView.adapter =UserAdapter(json)
                    }
                }
            }
            catch (e: Exception){
                e.printStackTrace()
            }
        }
    }

    class UserAdapter(val data:JSONArray) : RecyclerView.Adapter<UserAdapter.UserViewHolder>(){
        class UserViewHolder(itemView: View) : RecyclerView.ViewHolder(itemView){

            val title : TextView
            val check : CheckBox

            init {
                title = itemView.findViewById(R.id.title_text)
                check = itemView.findViewById(R.id.checkBox)
            }
        }

        override fun onCreateViewHolder(parent: ViewGroup, viewType: Int): UserViewHolder {
            val tukangrender = LayoutInflater.from(parent.context)
            val hasilrender = tukangrender.inflate(R.layout.user_card,parent,false)
            return  UserViewHolder((hasilrender))
        }

        override fun getItemCount(): Int {
            return data.length()
        }

        override fun onBindViewHolder(holder: UserViewHolder, position: Int) {
            val itembaris =data.getJSONObject(position)
            holder.title.text =itembaris.getString("title")

            val cek = itembaris.getBoolean("completed")
            holder.check.isChecked = cek
        }
    }
}