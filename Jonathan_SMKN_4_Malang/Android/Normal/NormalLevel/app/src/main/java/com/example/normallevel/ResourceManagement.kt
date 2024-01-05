package com.example.normallevel

import androidx.appcompat.app.AppCompatActivity
import android.os.Bundle
import android.widget.Button
import android.widget.ImageView

class ResourceManagement : AppCompatActivity() {

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.activity_resource_management)

        var button1 = findViewById<Button>(R.id.button1)
        var button2 = findViewById<Button>(R.id.button2)
        var button3 = findViewById<Button>(R.id.button3)

        var image = findViewById<ImageView>(R.id.imageView2)

        button1.setOnClickListener{
            image.setImageResource(R.drawable.superhero)
        }

        button2.setOnClickListener{
            image.setImageResource(R.drawable.superhero2)
        }

        button3.setOnClickListener{
            image.setImageResource(R.drawable.superhero3)
        }
    }
}