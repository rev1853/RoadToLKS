package com.example.basicandroid

import android.app.Activity
import androidx.appcompat.app.AppCompatActivity
import android.os.Bundle
import android.util.Log
import android.widget.Toast
import com.example.basicandroid.databinding.ActivityMain3Binding
import kotlinx.coroutines.Dispatchers
import kotlinx.coroutines.GlobalScope
import kotlinx.coroutines.launch
import org.json.JSONObject
import java.net.HttpURLConnection
import java.net.URL

class MainActivity3 : AppCompatActivity() {
    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        var binding = ActivityMain3Binding.inflate(layoutInflater)
        setContentView(binding.root)

        binding.saveBtn.setOnClickListener {
            finish()
        }

        binding.cancelBtn.setOnClickListener {
            var data = JSONObject().apply {
                put("name", binding.nameEt.text)
                put("rating", binding.ratingEt.text)
                put("image", binding.imageEt.text)
            }

            GlobalScope.launch(Dispatchers.IO) {
                val conn = URL("https://65dc2aa13ea883a152929961.mockapi.io/coffees").openConnection() as HttpURLConnection
                conn.requestMethod = "POST"
                conn.setRequestProperty("Content-Type", "application/json")

                conn.outputStream.write(data.toString().toByteArray())
                if (conn.responseCode == 201) {
                    setResult(Activity.RESULT_OK)
                    finish()
                } else {
                    runOnUiThread {
                        Toast.makeText(this@MainActivity3, "Gagal menambahkan data", Toast.LENGTH_SHORT).show()
                    }
                }
            }
        }
    }
}