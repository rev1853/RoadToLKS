package com.example.basicandroid

import androidx.appcompat.app.AppCompatActivity
import android.os.Bundle
import android.widget.Toast
import kotlinx.coroutines.Dispatchers
import kotlinx.coroutines.GlobalScope
import kotlinx.coroutines.launch
import java.net.URL

class MainActivity4 : AppCompatActivity() {
    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.activity_main4)

        val id = intent.getStringExtra("id")
        GlobalScope.launch(Dispatchers.IO) {
            val kofiStr = URL("https://65dc2aa13ea883a152929961.mockapi.io/coffees/$id").openStream().bufferedReader().readText()
            runOnUiThread {
                Toast.makeText(this@MainActivity4, kofiStr, Toast.LENGTH_SHORT).show()
            }
        }
    }
}