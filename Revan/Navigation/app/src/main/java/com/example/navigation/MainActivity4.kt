package com.example.navigation

import android.app.Activity
import android.content.Intent
import androidx.appcompat.app.AppCompatActivity
import android.os.Bundle
import com.example.navigation.databinding.ActivityMain4Binding

class MainActivity4 : AppCompatActivity() {
    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        val binding = ActivityMain4Binding.inflate(layoutInflater)
        setContentView(binding.root)

        binding.backBtn.setOnClickListener {
            finish()
        }

        binding.goBtn.setOnClickListener {
            setResult(Activity.RESULT_OK, Intent().apply {
                putExtra("nama", binding.nameEt.text.toString())
            })
            finish()
        }
    }
}