package com.example.navigation

import androidx.appcompat.app.AppCompatActivity
import android.os.Bundle
import android.view.MenuItem
import android.widget.Toast
import androidx.appcompat.app.ActionBarDrawerToggle
import com.example.navigation.databinding.ActivityMain6Binding
import com.example.navigation.databinding.SidebarHeaderBinding

class MainActivity6 : AppCompatActivity() {
    lateinit var toggle: ActionBarDrawerToggle
    lateinit var binding: ActivityMain6Binding
    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        binding = ActivityMain6Binding.inflate(layoutInflater)
        setContentView(binding.root)

        setSupportActionBar(binding.toolbar3)
        toggle = ActionBarDrawerToggle(this, binding.menuDl, R.string.open_txt, R.string.close_txt)

        binding.menuDl.addDrawerListener(toggle)
        toggle.syncState()

        supportActionBar?.setDisplayHomeAsUpEnabled(true)

        binding.menuNv.setNavigationItemSelectedListener {
            if (it.itemId == R.id.menu1) {
                val headerBinding = SidebarHeaderBinding.bind(binding.menuNv.getHeaderView(0))
                headerBinding.textTv.text = "test"
            }
            return@setNavigationItemSelectedListener true
        }
    }

    override fun onOptionsItemSelected(item: MenuItem): Boolean {
        toggle.onOptionsItemSelected(item)
        return true
    }
}