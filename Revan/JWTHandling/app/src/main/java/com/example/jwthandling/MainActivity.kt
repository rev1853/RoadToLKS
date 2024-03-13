package com.example.jwthandling

import android.content.Context
import android.content.Intent
import androidx.appcompat.app.AppCompatActivity
import android.os.Bundle
import android.util.Log
import android.widget.Button
import kotlinx.coroutines.Dispatchers
import kotlinx.coroutines.GlobalScope
import kotlinx.coroutines.launch
import org.json.JSONObject
import java.net.HttpURLConnection
import java.net.URL

class MainActivity : AppCompatActivity() {
    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.activity_main)

        var btn = findViewById<Button>(R.id.login_btn)

        var token = getSharedPreferences("JWTHandling", Context.MODE_PRIVATE).getString("token", null)
        if (token != null) {
            startActivity(Intent(this@MainActivity, MainActivity2::class.java).apply {
                flags = Intent.FLAG_ACTIVITY_CLEAR_TASK or Intent.FLAG_ACTIVITY_NEW_TASK
            })
        }

        btn.setOnClickListener {
            val data = JSONObject().apply {
                put("email", "admin@gmail.com")
                put("password", "admin")
            }

            GlobalScope.launch(Dispatchers.IO) {
                val conn = URL("http://10.0.2.2:8081/api/login").openConnection() as HttpURLConnection
                conn.requestMethod = "POST"
                conn.setRequestProperty("Content-Type", "application/json")

                conn.outputStream.write(data.toString().toByteArray())
                conn.outputStream.flush()
                conn.outputStream.close()

                var code = conn.responseCode
                Log.d("API", code.toString())

                if (code !in 200 .. 299) {
                    var errorMsg = conn.errorStream.bufferedReader().readText()
                    Log.d("API", errorMsg)
                } else {
                    val resObj = JSONObject(conn.inputStream.bufferedReader().readText())
                    Log.d("API", resObj.toString())
                    // cara 1
//                    Session.token = resObj.getString("token")

                    // cara 2
                    getSharedPreferences("JWTHandling", Context.MODE_PRIVATE).edit().apply {
                        putString("token", resObj.getString("token"))
                    }.apply()

                    startActivity(Intent(this@MainActivity, MainActivity2::class.java).apply {
                        flags = Intent.FLAG_ACTIVITY_CLEAR_TASK or Intent.FLAG_ACTIVITY_NEW_TASK
                    })
                }
            }
        }
    }
}