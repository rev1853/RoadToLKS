package com.example.androidnavigation

import android.content.Intent
import androidx.appcompat.app.AppCompatActivity
import android.os.Bundle
import android.widget.Button
import android.widget.EditText

class MainActivity2 : AppCompatActivity() {
    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.activity_main2)

        findViewById<Button>(R.id.back_btn).setOnClickListener {
            var intent = Intent().apply {
                putExtra("nama", findViewById<EditText>(R.id.nama_et).text.toString())
            }

            setResult(44, intent)
            finish()
        }
    }
}