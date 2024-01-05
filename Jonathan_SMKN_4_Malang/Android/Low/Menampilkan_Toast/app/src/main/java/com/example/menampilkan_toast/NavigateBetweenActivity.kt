package com.example.menampilkan_toast

import android.content.Intent
import androidx.appcompat.app.AppCompatActivity
import android.os.Bundle
import android.widget.Button

class NavigateBetweenActivity : AppCompatActivity() {
    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.activity_navigate_between)
        val butt1 = findViewById<Button>(R.id.nav1)
        val butt2 = findViewById<Button>(R.id.nav2)
        val butt3 = findViewById<Button>(R.id.nav3)
        val disable = findViewById<Button>(R.id.disable_bttn)


        butt1.setOnClickListener{
            val intent = Intent(this, NavigateBetweenActivity2::class.java)
            startActivity(intent)
        }

        butt2.setOnClickListener{
            val intent = Intent(this, NavigateBetweenActivity3::class.java)
            startActivity(intent)
        }

        butt3.setOnClickListener{
            val intent = Intent(this, NavigateBetweenActivity4::class.java)
            startActivity(intent)
        }

        disable.setOnClickListener{
            if (butt1.text == "Activity 1")
            {
                butt1.text = "Dont Click!"
                butt2.text = "Dont Click!"
                butt3.text = "Dont Click!"

                butt1.isEnabled = false
                butt2.isEnabled = false
                butt3.isEnabled = false
            }
            else{
                butt1.text = "Activity 1"
                butt2.text = "Activity 2"
                butt3.text = "Activity 3"

                butt1.isEnabled = true
                butt2.isEnabled = true
                butt3.isEnabled = true
            }
        }
    }
}