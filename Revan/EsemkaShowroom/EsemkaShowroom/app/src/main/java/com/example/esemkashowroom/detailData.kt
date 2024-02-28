package com.example.esemkashowroom

import android.content.Intent
import androidx.appcompat.app.AppCompatActivity
import android.os.Bundle
import android.util.Log
import android.widget.Button
import android.widget.TextView
import android.widget.Toast
import androidx.activity.result.contract.ActivityResultContracts
import androidx.appcompat.widget.AppCompatButton
import kotlinx.coroutines.Dispatchers
import kotlinx.coroutines.GlobalScope
import kotlinx.coroutines.launch
import org.json.JSONObject
import java.net.HttpURLConnection
import java.net.URL

class detailData : AppCompatActivity() {

    var updateLauncher = registerForActivityResult(ActivityResultContracts.StartActivityForResult()) {
        setResult(200)
        finish()
    }

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.activity_detail_data)

                val data = JSONObject(intent.getStringExtra("data_mobil"))

                val nama = findViewById<TextView>(R.id.d_nama)
                nama.text = data.getString("name")
                val model = findViewById<TextView>(R.id.d_model)
                model.text = data.getString("model")
                val brand = findViewById<TextView>(R.id.d_brand)
                brand.text = data.getString("brand")
                val year = findViewById<TextView>(R.id.d_tahun)
                year.text = data.getString("year")
                val update = findViewById<AppCompatButton>(R.id.update)
                update.setOnClickListener {

                   // val r = editText2.text.toString()
                    val intent = Intent(this, updateData::class.java)
                    intent.putExtra("updateData",data.toString())
                    updateLauncher.launch(intent)
                }




        val delete = findViewById<Button>(R.id.d_delete)
        delete.setOnClickListener {
            GlobalScope.launch(Dispatchers.IO) {
                var urlString = "https://6597231a668d248edf22a0d3.mockapi.io/Cars/${data.getString("id")}"

                val url = URL(urlString)
                val conn = url.openConnection() as HttpURLConnection
                conn.requestMethod = "DELETE"
                val code = conn.responseCode

                runOnUiThread {
                    if (code == 404) {
                        Toast.makeText(this@detailData, "Data cannot be deleted", Toast.LENGTH_SHORT).show()
                    } else {
                        Toast.makeText(this@detailData, "Successful deleting data", Toast.LENGTH_SHORT).show()
                        setResult(200)
                        finish()
                    }
                }
            }

        }
    }
}