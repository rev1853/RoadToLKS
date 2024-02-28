package com.example.databinding

import androidx.appcompat.app.AppCompatActivity
import android.os.Bundle
import androidx.databinding.BaseObservable
import androidx.lifecycle.LiveData
import androidx.lifecycle.MutableLiveData
import androidx.lifecycle.ViewModel
import com.example.databinding.databinding.ActivityMainBinding

class MainActivity : AppCompatActivity() {
    private lateinit var binding: ActivityMainBinding
    var name = MutableLiveData<String>("")

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        binding = ActivityMainBinding.inflate(layoutInflater)
        setContentView(binding.root)

        binding.data = this
        binding.lifecycleOwner = this

        binding.clickBtn.setOnClickListener {
            name.value = "John"
        }

        binding.click2Btn.setOnClickListener {
            name.value = "Mike"
        }

        binding.click3Btn.setOnClickListener {
            name.value = "Dave"
        }
    }
}