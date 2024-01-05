package com.example.counter

import androidx.appcompat.app.AppCompatActivity
import android.os.Bundle
import android.widget.Button
import android.widget.TextView

class MainActivity : AppCompatActivity() {
    var numberCounter = 1.0

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.activity_main)

        val textNumber = findViewById<TextView>(R.id.angka)

        findViewById<Button>(R.id.plus).setOnClickListener {
            numberCounter *= 2
            textNumber.text = numberCounter.toString()
        }

        findViewById<Button>(R.id.minus).setOnClickListener {
            numberCounter /= 0.5
            textNumber.text = numberCounter.toString()
        }
    }
}