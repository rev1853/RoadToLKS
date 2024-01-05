package com.example.navigatebetweenactivity

import android.content.Intent
import androidx.appcompat.app.AppCompatActivity
import android.os.Bundle
import android.widget.Button

class MainActivity : AppCompatActivity() {
    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.activity_main)

        val buttonActivity1 = findViewById<Button>(R.id.buttonActivity1)
        val buttonActivity2 = findViewById<Button>(R.id.buttonActivity2)
        val buttonActivity3 = findViewById<Button>(R.id.buttonActivity3)
        val buttonDisabled = findViewById<Button>(R.id.buttonDisabled)

        buttonActivity1.setOnClickListener {
            startActivity(Intent(this, MainActivity2::class.java))
        }
        buttonActivity2.setOnClickListener {
            startActivity(Intent(this, MainActivity3::class.java))
        }
        buttonActivity3.setOnClickListener {
            startActivity(Intent(this, MainActivity4::class.java))
        }
        buttonDisabled.setOnClickListener {
            buttonActivity1.isEnabled = !buttonActivity1.isEnabled
        }
    }
}