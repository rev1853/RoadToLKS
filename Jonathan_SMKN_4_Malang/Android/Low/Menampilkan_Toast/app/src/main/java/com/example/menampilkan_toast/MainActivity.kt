package com.example.menampilkan_toast

import androidx.appcompat.app.AppCompatActivity
import android.os.Bundle
import android.widget.Button
import android.widget.EditText
import android.widget.Toast

class MainActivity : AppCompatActivity() {
    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.activity_main)

        val show = findViewById<Button>(R.id.show_bttn)
        val text = findViewById<EditText>(R.id.editTextText)

        show.setOnClickListener {
            val teks = "Saya berjanji akan ${text.text}"
            Toast.makeText(this, teks, Toast.LENGTH_SHORT).show()
        }
    }
}
