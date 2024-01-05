package com.example.menampilkan_toast

import androidx.appcompat.app.AppCompatActivity
import android.os.Bundle
import android.widget.Button

class NavigateBetweenActivity3 : AppCompatActivity() {
    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.activity_navigate_between3)
        val back = findViewById<Button>(R.id.back3)

        back.setOnClickListener{
            finish()
        }

    }
}