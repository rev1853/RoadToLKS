package com.example.menampilkan_toast

import androidx.appcompat.app.AppCompatActivity
import android.os.Bundle
import android.widget.Button
import android.widget.TextView
import android.widget.Toast

class TambahBagiAngka : AppCompatActivity() {
    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.activity_tambah_bagi_angka)

        val data = findViewById<TextView>(R.id.textView)
        val tambah = findViewById<Button>(R.id.tambah)
        val kurang = findViewById<Button>(R.id.kurang)

        tambah.setOnClickListener{
            data.text = (data.text.toString().toFloat() * 2).toString()
        }

        kurang.setOnClickListener{
            data.text = (data.text.toString().toFloat() / 0.5).toString()
        }
    }
}