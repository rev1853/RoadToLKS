package com.example.navigation

import androidx.appcompat.app.AppCompatActivity
import android.os.Bundle
import android.util.Log
import kotlinx.coroutines.Dispatchers
import kotlinx.coroutines.GlobalScope
import kotlinx.coroutines.launch
import org.json.JSONObject
import java.net.HttpURLConnection
import java.net.URL

class MainActivity8 : AppCompatActivity() {
    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.activity_main8)

        GlobalScope.launch(Dispatchers.IO) {
            val conn = URL("http://10.0.2.2:5000/sign-up").openConnection() as HttpURLConnection
            conn.requestMethod = "POST"
            conn.setRequestProperty("Content-Type", "application/json")

            conn.outputStream.write(JSONObject().apply {
                put("firstName", "test")
                put("lastName", "test")
                put("password", "test")
                put("email", "email@gmail.com")
            }.toString().toByteArray())

            val res = conn.inputStream.bufferedReader().readText()
            Log.d("TEST", res)
        }
    }
}