package com.example.menampilkan_toast

import androidx.appcompat.app.AppCompatActivity
import android.os.Bundle
import android.widget.Button
import android.widget.EditText
import android.widget.TextView

class Simple_Calculator : AppCompatActivity() {
    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.activity_simple_calculator)

        val nilai1 = findViewById<EditText>(R.id.Angka1)
        val nilai2 = findViewById<EditText>(R.id.Angka2)
        val hasil = findViewById<TextView>(R.id.hasilangka)

        val plus = findViewById<Button>(R.id.plus)
        val minus = findViewById<Button>(R.id.minus)
        val bagi = findViewById<Button>(R.id.bagi)
        val kali = findViewById<Button>(R.id.kali)

        plus.setOnClickListener{
            hasil.text = "Hasilnya adalah... ${(nilai1.text.toString().toFloat() + nilai2.text.toString().toFloat()).toString()}"
        }

        minus.setOnClickListener{
            hasil.text = "Hasilnya adalah... ${(nilai1.text.toString().toFloat() - nilai2.text.toString().toFloat()).toString()}"
        }

        bagi.setOnClickListener{
            hasil.text = "Hasilnya adalah... ${(nilai1.text.toString().toFloat() / nilai2.text.toString().toFloat()).toString()}"
        }

        kali.setOnClickListener{
            kali.setOnClickListener {
                try {
                    val hasilKali = "Hasilnya adalah... ${nilai1.text.toString().toFloat() * nilai2.text.toString().toFloat()}"
                    hasil.text = hasilKali.toString()
                } catch (e: NumberFormatException) {
                    hasil.text = "Error: Invalid input"
                } catch (e: Exception) {
                    hasil.text = "Error: ${e.message}"
                }
            }

        }
    }
}