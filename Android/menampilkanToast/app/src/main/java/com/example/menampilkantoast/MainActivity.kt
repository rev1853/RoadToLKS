package com.example.menampilkantoast

import androidx.appcompat.app.AppCompatActivity
import android.os.Bundle
import android.widget.Button
import android.widget.EditText
import android.widget.Toast

class MainActivity : AppCompatActivity() {
    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.activity_main)

        findViewById<Button>(R.id.buttonTRY).setOnClickListener {
            val text = findViewById<EditText>(R.id.textToast)

            Toast.makeText(this, "data : ${text.text}", Toast.LENGTH_SHORT).show()
        }
    }
}