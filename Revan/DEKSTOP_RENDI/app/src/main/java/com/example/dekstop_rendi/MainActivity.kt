package com.example.dekstop_rendi

import android.content.Context
import androidx.appcompat.app.AppCompatActivity
import android.os.Bundle
import android.util.Log
import android.view.LayoutInflater
import android.view.View
import android.view.ViewGroup
import android.widget.LinearLayout
import android.widget.TextView
import androidx.appcompat.view.menu.ActionMenuItemView
import androidx.recyclerview.widget.LinearLayoutManager
import androidx.recyclerview.widget.RecyclerView
import androidx.recyclerview.widget.RecyclerView.Adapter
import kotlinx.coroutines.Dispatchers
import kotlinx.coroutines.GlobalScope
import kotlinx.coroutines.launch
import org.json.JSONArray
import java.net.HttpURLConnection
import java.net.URL

class MainActivity : AppCompatActivity() {
    private lateinit var adapter: List_Data
    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.activity_main)

        val bokl = findViewById<RecyclerView>(R.id.bookList)
        GlobalScope.launch(Dispatchers.IO) {
            val conn = URL("https://6597231a668d248edf22a0d3.mockapi.io/books").openConnection() as HttpURLConnection
            conn.requestMethod = "GET"

            val data = conn.inputStream.bufferedReader().readLine().toString()
            Log.d("BElAJAR_AI", data)

            GlobalScope.launch(Dispatchers.Main) {
                val buku = JSONArray(data)

                bokl.adapter = List_Data(buku)
                bokl.layoutManager = LinearLayoutManager(this@MainActivity)
            }
        }
    }
    class List_Data(var data: JSONArray) : RecyclerView.Adapter<List_Data.ViewHolder>(){
        class ViewHolder(itemView: View, val context: Context) : RecyclerView.ViewHolder(itemView){
                val tittle : TextView
                val Author : TextView
                val layout : LinearLayout
                init {
                    tittle = itemView.findViewById(R.id.tittleBook)
                    Author = itemView.findViewById(R.id.authorList)
                    layout = itemView.findViewById(R.id.bl1)
                }
        }

        override fun onCreateViewHolder(parent: ViewGroup, viewType: Int): ViewHolder {
            val layoutInflate = LayoutInflater.from(parent.context)
            val view = layoutInflate.inflate(R.layout.book_list, parent, false)
            return ViewHolder(view, parent.context)
        }

        override fun getItemCount(): Int {

            return data.length()
        }

        override fun onBindViewHolder(holder: ViewHolder, position: Int) {
            val item = data.getJSONObject(position)

            holder.tittle.text = item.getString("title")
            holder.Author.text = item.getString("author")
        }
    }
}