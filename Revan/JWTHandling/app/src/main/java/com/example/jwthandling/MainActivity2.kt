package com.example.jwthandling

import android.content.Context
import android.content.Intent
import androidx.appcompat.app.AppCompatActivity
import android.os.Bundle
import android.util.Log
import android.widget.Button
import android.widget.TextView
import kotlinx.coroutines.Dispatchers
import kotlinx.coroutines.GlobalScope
import kotlinx.coroutines.launch
import org.json.JSONObject
import java.net.HttpURLConnection
import java.net.URL

class MainActivity2 : AppCompatActivity() {
    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.activity_main2)

        findViewById<Button>(R.id.logout_btn).setOnClickListener {
            getSharedPreferences("JWTHandling", Context.MODE_PRIVATE).edit().apply {
                remove("token")
            }.apply()
            startActivity(Intent(this@MainActivity2, MainActivity::class.java).apply {
                flags = Intent.FLAG_ACTIVITY_CLEAR_TASK or Intent.FLAG_ACTIVITY_NEW_TASK
            })
        }

        GlobalScope.launch(Dispatchers.IO) {
            var conn = URL("http://10.0.2.2:8081/api/attendance/checkin/code").openConnection() as HttpURLConnection
            // cara 1
//            conn.setRequestProperty("Authorization", "Bearer ${Session.token}")
            // cara 2
            var token = getSharedPreferences("JWTHandling", Context.MODE_PRIVATE).getString("token", null)
            if (token != null) conn.setRequestProperty("Authorization", "Bearer $token")

            var code = conn.responseCode

            if (code !in 200 .. 299) {
                if (code == 403) {
                    startActivity(Intent(this@MainActivity2, MainActivity::class.java).apply {
                        flags = Intent.FLAG_ACTIVITY_CLEAR_TASK or Intent.FLAG_ACTIVITY_NEW_TASK
                    })
                } else {
                    var errorMsg = conn.errorStream.bufferedReader().readText()
                    runOnUiThread {
                        findViewById<TextView>(R.id.user_tv).text = errorMsg
                    }
                }
            } else {
                var resObj = JSONObject(conn.inputStream.bufferedReader().readText())
                runOnUiThread {
                    findViewById<TextView>(R.id.user_tv).text = resObj.getString("code")
                }
            }

        }
    }
}