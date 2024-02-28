package com.example.navigation

import androidx.appcompat.app.AppCompatActivity
import android.os.Bundle
import android.widget.ArrayAdapter
import androidx.fragment.app.Fragment
import androidx.viewpager2.adapter.FragmentStateAdapter
import androidx.viewpager2.widget.ViewPager2
import com.example.navigation.databinding.ActivityMain5Binding
import com.google.android.material.tabs.TabLayoutMediator

class MainActivity5 : AppCompatActivity() {
    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        val binding = ActivityMain5Binding.inflate(layoutInflater)
        setContentView(binding.root)


        val fragments = listOf(SatuFragment(), SecondFragment(), UbigFragment())
        val menuNames = listOf("Satu", "Dua", "Tiga")
        binding.menuVp.adapter = object : FragmentStateAdapter(supportFragmentManager, lifecycle) {
            override fun getItemCount(): Int = fragments.size
            override fun createFragment(pos: Int): Fragment = fragments[pos]
        }

        TabLayoutMediator(binding.menuTl, binding.menuVp) { tab, pos ->
            tab.text = menuNames[pos]
        }.attach()
    }
}