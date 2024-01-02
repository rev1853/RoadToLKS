package com.example.belajarandroid_web_api_01

import androidx.appcompat.app.AppCompatActivity
import android.os.Bundle
import android.util.Log
import android.view.LayoutInflater
import android.view.View
import android.view.ViewGroup
import android.widget.TextView
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

        GlobalScope.launch (Dispatchers.IO){
            var url = URL("http://10.0.2.2:5138/api/Clan/clan")
            var conn = url.openConnection() as HttpURLConnection
            conn.requestMethod="GET"


            var dataYangDiambil =conn.inputStream.bufferedReader().readLines().toString()
            Log.d("clan", dataYangDiambil)

            GlobalScope.launch(Dispatchers.Main){
                val user =JSONArray(dataYangDiambil).getJSONArray(0)
                val list =findViewById<RecyclerView>(R.id.list)
                list.adapter = Adapter(user)
                list.layoutManager=LinearLayoutManager(this@MainActivity)

            }
        }

    }

    class Adapter (val data : JSONArray): RecyclerView.Adapter<Adapter.viewholder>() {
        class viewholder(itemView: View) : RecyclerView.ViewHolder(itemView){
            val Nama : TextView = itemView.findViewById(R.id.name)
            val Desc : TextView = itemView.findViewById(R.id.description)
        }

        override fun onCreateViewHolder(parent: ViewGroup, viewType: Int): viewholder {
            val before =LayoutInflater.from(parent.context)
            val after = before.inflate(R.layout.clan_list,parent,false)
            return viewholder(after)
        }

        override fun getItemCount(): Int {
            return data.length()
        }

        override fun onBindViewHolder(holder: viewholder, position: Int) {
           val item = data.getJSONObject(position)
            holder.Nama.text = item.getString("name")
            holder.Desc.text = item.getString("description")

        }
    }

}