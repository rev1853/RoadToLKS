package com.example.esemkapetition

import android.content.Intent
import androidx.appcompat.app.AppCompatActivity
import android.os.Bundle
import androidx.appcompat.app.AlertDialog
import com.example.esemkapetition.databinding.ActivityMainBinding
import kotlinx.coroutines.Dispatchers
import kotlinx.coroutines.GlobalScope
import kotlinx.coroutines.coroutineScope
import kotlinx.coroutines.launch
import kotlinx.coroutines.withContext
import org.json.JSONObject
import java.net.HttpURLConnection
import java.net.URL
import kotlin.math.log

class MainActivity : AppCompatActivity() {
    private lateinit var binding: ActivityMainBinding

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        binding = ActivityMainBinding.inflate(layoutInflater)
        setContentView(binding.root)

        binding.signInBtn.setOnClickListener {
            GlobalScope.launch(Dispatchers.IO) {
                val conn = URL("http://10.0.2.2:5000/sign-in").openConnection() as HttpURLConnection
                conn.requestMethod = "POST"
                conn.setRequestProperty("Content-Type", "application/json")

                val data = JSONObject().apply {
                    put("email", binding.emailEt.text.toString())
                    put("password", binding.passwordEt.text.toString())
                }
                conn.outputStream.write(data.toString().toByteArray())

                val isSuccess = conn.responseCode in 200..299
                val user = JSONObject(conn.inputStream?.bufferedReader()?.readText() ?: "{}")
                val errorStr = conn.errorStream?.bufferedReader()?.readText()

                runOnUiThread {
                    if (isSuccess) {
                        
                        startActivity(Intent(this@MainActivity, MainActivity3::class.java).apply {
                            addFlags(Intent.FLAG_ACTIVITY_CLEAR_TOP or Intent.FLAG_ACTIVITY_CLEAR_TASK)
                        })
                    } else {
                        AlertDialog.Builder(this@MainActivity)
                            .setTitle("Failed")
                            .setMessage(errorStr)
                            .show()
                    }
                }
            }
        }
    }
}