package com.example.myapplication

import androidx.appcompat.app.AppCompatActivity
import android.os.Bundle
import android.util.Log
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

        val booklist = findViewById<RecyclerView>(R.id.bookList)
        GlobalScope.launch(Dispatchers.IO) {
            val conn = URL("https://6597231a668d248edf22a0d3.mockapi.io/books").openConnection() as HttpURLConnection
            conn.requestMethod = "GET"
            val respon = conn.responseCode

            val data = conn.inputStream.bufferedReader().readText()
            Log.d("BElAJAR_AI", data)

        }
    }
}