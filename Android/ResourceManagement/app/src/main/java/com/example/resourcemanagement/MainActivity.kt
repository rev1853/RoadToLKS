package com.example.resourcemanagement

import androidx.appcompat.app.AppCompatActivity
import android.os.Bundle
import android.widget.Button
import android.widget.ImageView

class MainActivity : AppCompatActivity() {
    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.activity_main)

        findViewById<Button>(R.id.button1).setOnClickListener {
            findViewById<ImageView>(R.id.imageViews).setBackgroundResource(R.drawable.superhero)
        }
        findViewById<Button>(R.id.button2).setOnClickListener {
            findViewById<ImageView>(R.id.imageViews).setBackgroundResource(R.drawable.superhero__1_)
        }
        findViewById<Button>(R.id.button3).setOnClickListener {
            findViewById<ImageView>(R.id.imageViews).setBackgroundResource(R.drawable.superhero__2_)
        }
    }
}