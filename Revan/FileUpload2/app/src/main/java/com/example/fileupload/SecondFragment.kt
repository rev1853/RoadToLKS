package com.example.fileupload

import android.os.Bundle
import androidx.fragment.app.Fragment
import android.view.LayoutInflater
import android.view.View
import android.view.ViewGroup
import androidx.recyclerview.widget.LinearLayoutManager
import androidx.recyclerview.widget.LinearSnapHelper
import androidx.recyclerview.widget.PagerSnapHelper
import androidx.recyclerview.widget.RecyclerView
import com.example.fileupload.databinding.FragmentSecondBinding
import com.example.fileupload.databinding.ItemLayoutBinding

class SecondFragment : Fragment() {

    override fun onCreateView(
        inflater: LayoutInflater, container: ViewGroup?,
        savedInstanceState: Bundle?
    ): View? {
        val binding = FragmentSecondBinding.inflate(inflater, container, false)

        class ViewHolder(val binding: ItemLayoutBinding) : RecyclerView.ViewHolder(binding.root)
        val adapter = object : RecyclerView.Adapter<ViewHolder>() {
            override fun onCreateViewHolder(parent: ViewGroup, viewType: Int): ViewHolder {
                val binding = ItemLayoutBinding.inflate(LayoutInflater.from(parent.context), parent, false)
                return ViewHolder(binding)
            }

            override fun getItemCount(): Int = 5

            override fun onBindViewHolder(holder: ViewHolder, position: Int) {
                holder.binding.testTv.text = "Item ${position + 1}"
            }

        }
        binding.testRv.adapter = adapter
        binding.testRv.layoutManager = LinearLayoutManager(context, LinearLayoutManager.HORIZONTAL, false)

        var snapHelper = PagerSnapHelper()
        snapHelper.attachToRecyclerView(binding.testRv)
        return binding.root
    }
}