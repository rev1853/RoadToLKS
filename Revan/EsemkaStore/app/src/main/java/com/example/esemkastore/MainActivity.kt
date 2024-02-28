package com.example.esemkastore

import androidx.appcompat.app.AppCompatActivity
import android.os.Bundle
import android.util.Log
import android.view.LayoutInflater
import android.view.View
import android.view.ViewGroup
import android.widget.Button
import android.widget.EditText
import android.widget.TextView
import androidx.core.widget.addTextChangedListener
import androidx.recyclerview.widget.LinearLayoutManager
import androidx.recyclerview.widget.RecyclerView
import kotlinx.coroutines.Dispatchers
import kotlinx.coroutines.GlobalScope
import kotlinx.coroutines.launch
import org.json.JSONArray
import java.net.HttpURLConnection
import java.net.URL

class MainActivity : AppCompatActivity() {
    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.activity_main)

        val recyclerView = findViewById<RecyclerView>(R.id.books_rv)
        val input = findViewById<EditText>(R.id.search_et)

        input.addTextChangedListener {
            GlobalScope.launch(Dispatchers.IO) {
                val result = URL("https://6597231a668d248edf22a0d3.mockapi.io/books?search=${input.text}").openStream().bufferedReader().readText()
                val json = JSONArray(result)

                runOnUiThread {
                    recyclerView.adapter = BookAdapter(json)
                    recyclerView.layoutManager = LinearLayoutManager(this@MainActivity)
                }
            }
        }



        GlobalScope.launch(Dispatchers.IO) {
            val result = URL("https://6597231a668d248edf22a0d3.mockapi.io/books").openStream().bufferedReader().readText()
            val json = JSONArray(result)

            runOnUiThread {
                recyclerView.adapter = BookAdapter(json)
                recyclerView.layoutManager = LinearLayoutManager(this@MainActivity)
            }
        }
    }


    class BookAdapter(val json: JSONArray) : RecyclerView.Adapter<BookViewHolder>() {
        override fun onCreateViewHolder(parent: ViewGroup, viewType: Int): BookViewHolder {
            val layoutInflater = LayoutInflater.from(parent.context)
            val layout = layoutInflater.inflate(R.layout.recycleview_book, parent, false)
            return BookViewHolder(layout)
        }

        override fun getItemCount(): Int {
            return json.length()
        }

        override fun onBindViewHolder(holder: BookViewHolder, position: Int) {
            val item = json.getJSONObject(position)

            holder.titleTv.text = item.getString("title")
            holder.authorTv.text = item.getString("author")

        }

    }

    class BookViewHolder(itemView: View) : RecyclerView.ViewHolder(itemView) {
        val titleTv: TextView = itemView.findViewById(R.id.title_tv)
        val authorTv: TextView = itemView.findViewById(R.id.author_tv)
        val detailBtn: Button = itemView.findViewById(R.id.detail_btn)
    }
}