package com.example.fileupload

import androidx.appcompat.app.AppCompatActivity
import android.os.Bundle
import android.widget.Toast
import androidx.core.view.get
import androidx.fragment.app.Fragment
import androidx.fragment.app.FragmentActivity
import com.example.fileupload.databinding.ActivityMain2Binding
import com.google.android.material.tabs.TabLayout
import com.google.android.material.tabs.TabLayout.OnTabSelectedListener

class MainActivity2 : AppCompatActivity() {
    private lateinit var binding: ActivityMain2Binding
    private val fragments = listOf(FirstFragment(), SecondFragment())
    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        binding = ActivityMain2Binding.inflate(layoutInflater)
        setContentView(binding.root)

        val menus = listOf("Menu 1", "Menu 2")

        for (menu in menus) {
            val tab = binding.menuTl.newTab()
            tab.text = menu
            tab.tag = fragments[menus.indexOf(menu)]
            binding.menuTl.addTab(tab)
        }

        showFragment(fragments[0])

        supportFragmentManager.addOnBackStackChangedListener {
            val fragment = supportFragmentManager.findFragmentById(binding.containerFl.id)
            val index = fragments.indexOf(fragment)
            if (index != -1) binding.menuTl.getTabAt(index)?.select()
        }

        binding.menuTl.addOnTabSelectedListener(object : OnTabSelectedListener {
            override fun onTabSelected(tab: TabLayout.Tab?) {
                tab?.let {
                    showFragment(it.tag as Fragment, true)
                }
            }

            override fun onTabUnselected(tab: TabLayout.Tab?) { }

            override fun onTabReselected(tab: TabLayout.Tab?) { }
        })
    }

    fun showFragment(fragment: Fragment, addToBackStage: Boolean = false) {
        val transaction = supportFragmentManager.beginTransaction()
        transaction.replace(binding.containerFl.id, fragment)
        if (addToBackStage) transaction.addToBackStack(null)
        transaction.commit()
    }
}