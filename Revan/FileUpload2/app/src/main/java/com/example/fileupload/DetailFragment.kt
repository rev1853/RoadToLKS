package com.example.fileupload

import android.os.Bundle
import androidx.fragment.app.Fragment
import android.view.LayoutInflater
import android.view.View
import android.view.ViewGroup
import android.widget.Toast
import com.example.fileupload.databinding.FragmentDetailBinding
import kotlinx.coroutines.GlobalScope


class DetailFragment : Fragment() {

    override fun onCreateView(
        inflater: LayoutInflater, container: ViewGroup?,
        savedInstanceState: Bundle?
    ): View? {
        val binding = FragmentDetailBinding.inflate(inflater, container, false)


        arguments?.let {
            binding.inputTv.text = it.getString("input")
            Toast.makeText(context, "test", Toast.LENGTH_SHORT).show()
        }

        return binding.root
    }
}