package com.example.pindah_menu

import android.content.Intent
import androidx.appcompat.app.AppCompatActivity
import android.os.Bundle
import android.widget.Button

class MainActivity : AppCompatActivity() {
    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.activity_main)

        val Button_Menu2 = findViewById<Button>(R.id.Button1)
        val Button_Menu3 = findViewById<Button>(R.id.Button2)

        Button_Menu2.setOnClickListener {
            val Pindah = Intent(this, MainActivity2::class.java)
            startActivity(Pindah)
        }

        Button_Menu3.setOnClickListener {
            val Pindah1 = Intent(this, MainActivity3::class.java)
            startActivity(Pindah1)
        }
    }
}