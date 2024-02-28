package com.example.navigation

import android.app.Activity
import android.content.Intent
import androidx.appcompat.app.AppCompatActivity
import android.os.Bundle
import com.example.navigation.databinding.ActivityMain2Binding

class MainActivity2 : AppCompatActivity() {
    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        val binding = ActivityMain2Binding.inflate(layoutInflater)
        setContentView(binding.root)

        binding.cancelBtn.setOnClickListener {
            finish()
        }

        binding.submitBtn.setOnClickListener {
            setResult(Activity.RESULT_OK, Intent().apply {
                putExtra("nama", binding.namaEt.text.toString())
            })
            finish()
        }
    }
}