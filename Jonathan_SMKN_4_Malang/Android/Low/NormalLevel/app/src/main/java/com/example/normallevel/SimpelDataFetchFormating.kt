package com.example.normallevel

import android.os.Bundle
import android.util.Log
import android.widget.TextView
import androidx.appcompat.app.AppCompatActivity
import kotlinx.coroutines.Dispatchers
import kotlinx.coroutines.GlobalScope
import kotlinx.coroutines.launch
import org.json.JSONArray
import org.json.JSONObject
import java.net.HttpURLConnection
import java.net.URL
import java.text.NumberFormat
import java.util.Locale

class SimpelDataFetchFormating : AppCompatActivity() {

    private lateinit var titleTextView: TextView
    private lateinit var descTextView: TextView
    private lateinit var priceTextView: TextView
    private lateinit var stockTextView: TextView

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.activity_simpel_data_fetch_formating)

        titleTextView = findViewById(R.id.title)
        descTextView = findViewById(R.id.desc)
        priceTextView = findViewById(R.id.price)
        stockTextView = findViewById(R.id.stock)

        GlobalScope.launch(Dispatchers.IO) {
                val url = URL("https://dummyjson.com/products/3")
                val conn = url.openConnection() as HttpURLConnection
                conn.requestMethod = "GET"

                val result = conn.inputStream.bufferedReader().readLines().toString()

                val json = JSONArray(result).getJSONObject(0)
                Log.d("josn", json.toString())
                // Mendapatkan data dari JSON
                val title = json.getString("title")
                val description = json.getString("description")
                val price = json.getDouble("price")
                val stock = json.getInt("stock")

                // Memformat harga sebagai mata uang Rupiah
                val currencyFormat = NumberFormat.getCurrencyInstance(Locale("id", "ID"))
                val formattedPrice = currencyFormat.format(price)

                // Memformat stok dengan pemisah ribuan
                val formattedStock = NumberFormat.getNumberInstance(Locale.US).format(stock)

                // Memperbarui TextView di thread UI
                launch(Dispatchers.Main) {
                    titleTextView.text = title
                    descTextView.text = description
                    priceTextView.text = "Price: $formattedPrice"
                    stockTextView.text = "Stock: $formattedStock"
                }
        }
    }
}
