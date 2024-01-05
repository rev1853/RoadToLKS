package com.example.recyclerviewandcustomlayout

import androidx.appcompat.app.AppCompatActivity
import android.os.Bundle
import android.util.Log
import android.view.LayoutInflater
import android.view.View
import android.view.ViewGroup
import android.widget.CheckBox
import android.widget.LinearLayout
import android.widget.TextView
import androidx.appcompat.view.menu.MenuView.ItemView
import androidx.recyclerview.widget.LinearLayoutManager
import androidx.recyclerview.widget.RecyclerView
import kotlinx.coroutines.Dispatchers
import kotlinx.coroutines.GlobalScope
import kotlinx.coroutines.launch
import org.json.JSONArray
import java.io.BufferedReader
import java.net.HttpURLConnection
import java.net.URL
import java.nio.file.attribute.AclEntry.Builder

class MainActivity : AppCompatActivity() {
    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.activity_main)

        val dataRF = findViewById<RecyclerView>(R.id.dataRF)

        GlobalScope.launch(Dispatchers.IO) {
            val url = URL("https://jsonplaceholder.typicode.com/todos")
            val conn = url.openConnection() as HttpURLConnection
            conn.requestMethod = "GET"

            val response = conn.inputStream.bufferedReader().use(BufferedReader::readText)
            val data = JSONArray(response)

            GlobalScope.launch(Dispatchers.Main) {
                dataRF.adapter = AdapterViewsData(data)
                dataRF.layoutManager = LinearLayoutManager(this@MainActivity)
            }
        }
    }

    class AdapterViewsData(val data: JSONArray): RecyclerView.Adapter<AdapterViewsData.HolderViews>() {
        class HolderViews(view: View): RecyclerView.ViewHolder(view){
            val title: TextView
            val complate: CheckBox

            init {
                title = view.findViewById(R.id.title)
                complate = view.findViewById(R.id.completed)
            }
        }

        override fun onCreateViewHolder(parent: ViewGroup, viewType: Int): HolderViews {
            val layoutInfalter = LayoutInflater.from(parent.context)
            val view = layoutInfalter.inflate(R.layout.item_data, parent, false)
            return HolderViews(view)
        }

        override fun getItemCount(): Int {
            return data.length()
        }

        override fun onBindViewHolder(holder: HolderViews, position: Int) {
            val result = data.getJSONObject(position)

            holder.title.text = result.getString("title").toString()
            holder.complate.isChecked = result.getBoolean("completed").toString().toBoolean()
        }
    }
}