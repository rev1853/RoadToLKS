package com.example.simpedatafetchandformatting

import androidx.appcompat.app.AppCompatActivity
import android.os.Bundle
import android.util.Log
import android.widget.TextView
import kotlinx.coroutines.Dispatchers
import kotlinx.coroutines.GlobalScope
import kotlinx.coroutines.launch
import org.json.JSONArray
import org.json.JSONObject
import java.net.HttpURLConnection
import java.net.URL
import java.text.NumberFormat
import java.util.Locale

class MainActivity : AppCompatActivity() {
    fun rupiah(number: Double): String{
        val localeID =  Locale("in", "ID")
        val numberFormat = NumberFormat.getCurrencyInstance(localeID)
        return numberFormat.format(number).toString()
    }

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.activity_main)


        GlobalScope.launch(Dispatchers.IO) {
            val url = URL("https://dummyjson.com/products/3")
            val conn = url.openConnection() as HttpURLConnection
            conn.requestMethod = "GET"

            val result = conn.inputStream.bufferedReader().readLines().toString()
            val data = JSONArray(result).getJSONObject(0)

            GlobalScope.launch(Dispatchers.Main) {
                findViewById<TextView>(R.id.titleData).text = data.getString("title")
                findViewById<TextView>(R.id.descriptionData).text = data.getString("description")
                findViewById<TextView>(R.id.priceData).text = rupiah(data.getInt("price").toDouble())
                findViewById<TextView>(R.id.stokData).text = data.getInt("stock").toString()
            }
        }
    }
}