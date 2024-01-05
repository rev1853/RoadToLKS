package com.example.pindah_menu

import androidx.appcompat.app.AppCompatActivity
import android.os.Bundle
import android.util.Log
import android.view.LayoutInflater
import android.view.View
import android.view.ViewGroup
import android.widget.TextView
import androidx.appcompat.view.menu.MenuView.ItemView
import androidx.recyclerview.widget.LinearLayoutManager
import androidx.recyclerview.widget.RecyclerView
import androidx.recyclerview.widget.RecyclerView.ViewHolder
import org.json.JSONArray
import org.json.JSONObject

class MainActivity2 : AppCompatActivity() {
    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.activity_main2)

        //Langsung paste data
        val jsonKu = "[\n" +
                "  {\n" +
                "    \"id\": 1,\n" +
                "    \"nama\": \"Jonathan\",\n" +
                "    \"gender\": \"Laki - Laki\",\n" +
                "    \"kota\": \"Malang\"\n" +
                "  },\n" +
                "  {\n" +
                "    \"id\": 2,\n" +
                "    \"nama\": \"Edsel\",\n" +
                "    \"gender\": \"Laki - Laki\",\n" +
                "    \"kota\": \"Malang\"\n" +
                "  },\n" +
                "  {\n" +
                "    \"id\": 3,\n" +
                "    \"nama\": \"Radhit\",\n" +
                "    \"gender\": \"Laki - Laki\",\n" +
                "    \"kota\": \"Bondowoso\"\n" +
                "  }\n" +
                "]"

//        val jsonObject = JSONObject(jsonKu).getJSONObject("menu").getString("value").toString()
//        Log.d("Tes", jsonObject)


        //Tulis manual
        val dataku = JSONArray().apply {
            put(JSONObject().apply {
                put("id", 0)
                put("name", "Jonathan")
                put("gender", "Laki - laki")
                put("asal", "Malang")
            })
            put(JSONObject().apply {
                put("id", 0)
                put("name", "Edsel")
                put("gender", "Laki - laki")
                put("asal", "Malang")
            })
            put(JSONObject().apply {
                put("id", 0)
                put("name", "Radhit")
                put("gender", "Laki - laki")
                put("asal", "Bondowoso")
            })
        }

        Log.d("Dataku", dataku.toString())

        val list = findViewById<RecyclerView>(R.id.list_teman)
        list.adapter = TemanAdapter(dataku)
        list.layoutManager = LinearLayoutManager(this)
    }

    class TemanAdapter(val data: JSONArray) : RecyclerView.Adapter<TemanAdapter.TemanViewHolder>() {
        class TemanViewHolder(itemView: View) : RecyclerView.ViewHolder(itemView) {
            val nama_teman: TextView
            val nama_kota: TextView

            init {
                nama_teman = itemView.findViewById(R.id.Nama_Teman)
                nama_kota = itemView.findViewById(R.id.kota_teman)
            }
        }

        override fun onCreateViewHolder(parent: ViewGroup, viewType: Int): TemanViewHolder {
            // Cara Render
            val tukangrender = LayoutInflater.from(parent.context)
            val hasil_render = tukangrender.inflate(R.layout.teman_saya_card, parent, false)
            return TemanViewHolder(hasil_render)
        }

        override fun getItemCount(): Int {
            return data.length()
        }

        override fun onBindViewHolder(holder: TemanViewHolder, position: Int) {
            val itemperbaris = data.getJSONObject(position)
            holder.nama_teman.text = itemperbaris.getString("name")
            holder.nama_kota.text = itemperbaris.getString("asal")
        }
    }
}