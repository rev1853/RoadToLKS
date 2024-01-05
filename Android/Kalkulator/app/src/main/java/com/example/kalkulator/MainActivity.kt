package com.example.kalkulator

import androidx.appcompat.app.AppCompatActivity
import android.os.Bundle
import android.widget.Button
import android.widget.EditText
import android.widget.TextView

class MainActivity : AppCompatActivity() {
    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.activity_main)

        val angka1 = findViewById<EditText>(R.id.nomor1)
        val angka2 = findViewById<EditText>(R.id.nomor2)
        val hasil = findViewById<TextView>(R.id.textHasil)

        findViewById<Button>(R.id.plusButton).setOnClickListener {
            hasil.text ="Hasil "+(angka1.text.toString().toInt() + angka2.text.toString().toInt()).toString()
        }

        findViewById<Button>(R.id.minusButton).setOnClickListener {
            hasil.text = "Hasil "+ (angka1.text.toString().toInt() - angka2.text.toString().toInt()).toString()
        }

        findViewById<Button>(R.id.kaliButton).setOnClickListener {
            hasil.text = "Hasil "+ (angka1.text.toString().toInt() * angka2.text.toString().toInt()).toString()
        }

        findViewById<Button>(R.id.defideButton).setOnClickListener {
            if (angka2.text.toString().toInt() == 0) {
                hasil.text = "Tak terhingga"
            } else {
                hasil.text = "Hasil "+ (angka1.text.toString().toInt() / angka2.text.toString().toInt()).toString()
            }
        }
    }
}