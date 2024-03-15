package com.example.fileupload

import android.os.Bundle
import androidx.fragment.app.Fragment
import android.view.LayoutInflater
import android.view.View
import android.view.ViewGroup
import com.example.fileupload.databinding.FragmentFirstBinding

class FirstFragment : Fragment() {

    override fun onCreateView(
        inflater: LayoutInflater, container: ViewGroup?,
        savedInstanceState: Bundle?
    ): View? {
        val binding = FragmentFirstBinding.inflate(inflater, container, false)

        binding.sendBtn.setOnClickListener {
            val input = binding.nameEt.text.toString()

            if (activity is MainActivity2) {
                val fragment = DetailFragment().apply {
                    arguments = Bundle().apply {
                        putString("input", input)
                    }
                }
                (activity as MainActivity2)?.showFragment(fragment, true)
            }

        }

        return binding.root
    }
}