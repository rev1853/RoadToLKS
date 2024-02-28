package com.example.basicandroid

import android.content.Context
import android.content.Intent
import androidx.appcompat.app.AppCompatActivity
import android.os.Bundle
import android.util.Log
import android.widget.Button
import android.widget.EditText
import android.widget.Toast
import com.example.basicandroid.databinding.ActivityMainBinding
import kotlinx.coroutines.Dispatchers
import kotlinx.coroutines.GlobalScope
import kotlinx.coroutines.launch
import org.json.JSONObject
import java.net.HttpURLConnection
import java.net.URL

class MainActivity : AppCompatActivity() {

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        var binding = ActivityMainBinding.inflate(this.layoutInflater)
        setContentView(binding.root)
        binding.usernameTv.setText("kminchelle")
        binding.passwordTv.setText("0lelplR")


        binding.btnLogin.setOnClickListener {
            GlobalScope.launch(Dispatchers.IO) {
                var url = URL("https://dummyjson.com/auth/login")
                var conn = url.openConnection() as HttpURLConnection
                conn.requestMethod = "POST"
                conn.setRequestProperty("Content-Type", "application/json")

                var dataAuth = JSONObject().apply {
                    put("username", binding.usernameTv.text)
                    put("password", binding.passwordTv.text)
                }
                conn.outputStream.write(dataAuth.toString().toByteArray())

                var code = conn.responseCode

                if (code == 200) {
                    var jsonStr = conn.inputStream.bufferedReader().readText()
                    var user = JSONObject(jsonStr)

                    runOnUiThread {
                        var editor = getSharedPreferences("random", Context.MODE_PRIVATE).edit()
                        editor.putString("user", jsonStr)
                        editor.apply()

                        startActivity(Intent(this@MainActivity, MainActivity2::class.java))
                        Toast.makeText(this@MainActivity, "Selamat datang ${user.getString("firstName")}", Toast.LENGTH_SHORT).show()
                    }
                } else {
                    var jsonStr = conn.errorStream.bufferedReader().readText()
                    var error = JSONObject(jsonStr)

                    runOnUiThread {
                        Toast.makeText(this@MainActivity, "Authentication faile, reason: ${error.getString("message")}", Toast.LENGTH_LONG).show()
                    }
                }

            }
        }
    }
}