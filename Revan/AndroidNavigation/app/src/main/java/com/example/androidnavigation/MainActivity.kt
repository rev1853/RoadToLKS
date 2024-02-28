package com.example.androidnavigation

import android.content.Intent
import androidx.appcompat.app.AppCompatActivity
import android.os.Bundle
import android.widget.Button
import android.widget.Toast
import androidx.activity.result.contract.ActivityResultContracts

class MainActivity : AppCompatActivity() {

    var activity2Launcher = registerForActivityResult(ActivityResultContracts.StartActivityForResult()) {
        var data = it.data?.getStringExtra("nama") ?: "Ndak Masuk"
        Toast.makeText(this, data, Toast.LENGTH_LONG).show()
    }
    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.activity_main)

        findViewById<Button>(R.id.navigate_btn).setOnClickListener {
            activity2Launcher.launch(Intent(this, MainActivity2::class.java))
        }
    }
}