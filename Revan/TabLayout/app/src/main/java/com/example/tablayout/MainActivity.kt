package com.example.tablayout

import androidx.appcompat.app.AppCompatActivity
import android.os.Bundle
import android.widget.Toast
import com.google.android.material.tabs.TabLayout
import com.google.android.material.tabs.TabLayout.OnTabSelectedListener
import org.json.JSONArray
import org.json.JSONObject

class MainActivity : AppCompatActivity() {
    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.activity_main)

        val categories = JSONArray().apply {
            put(JSONObject().apply {
                put("id", 1)
                put("category", "Americano")
            })
            put(JSONObject().apply {
                put("id", 2)
                put("category", "Espresso")
            })
            put(JSONObject().apply {
                put("id", 3)
                put("category", "Mocha")
            })
            put(JSONObject().apply {
                put("id", 4)
                put("category", "Cappuccino")
            })
            put(JSONObject().apply {
                put("id", 5)
                put("category", "Latte")
            })
            put(JSONObject().apply {
                put("id", 6)
                put("category", "Machiato")
            })
            put(JSONObject().apply {
                put("id", 7)
                put("category", "Nescafe")
            })
        }

        val tabLayout = findViewById<TabLayout>(R.id.category_tl)

        tabLayout.addOnTabSelectedListener(object : OnTabSelectedListener {
            override fun onTabSelected(tab: TabLayout.Tab?) {
                tab?.let {
                    val category = it.tag as JSONObject
                    Toast.makeText(this@MainActivity, "Category: ${category.getString("category")}, ID: ${category.getDouble("id")}", Toast.LENGTH_SHORT).show()
                }
            }

            override fun onTabUnselected(tab: TabLayout.Tab?) { }
            override fun onTabReselected(tab: TabLayout.Tab?) {
                tabLayout.selectTab(null, true)
            }
        })

        for (i in 0..< categories.length()) {
            val category = categories.getJSONObject(i)
            val tab = tabLayout.newTab()
            tab.tag = category
            tab.text = category.getString("category")
            tabLayout.addTab(tab)
        }
    }
}