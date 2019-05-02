using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImplementTrie : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	/**
	数据结构的实现：字典树
	 */
	public class Trie {
    
		public static int SIZE = 26;
		
		public Node root;
		
		public class Node{
			public char ch;
			public Node[] childNodes;
			public bool isEnd;
			
			public Node(){
				isEnd = false;
				childNodes = new Node[26];
			}
		}

		/** Initialize your data structure here. */
		public Trie() {
			root = new Node();
		}
		
		/** Inserts a word into the trie. */
		public void Insert(string word) {
			if(string.IsNullOrEmpty(word)) return ;
			
			char[] chars = word.ToCharArray();
			
			Node node = root;
			for(int i = 0; i < chars.Length; i++){
				int index = chars[i] - 'a';
				if(node.childNodes[index] == null){
					node.childNodes[index] = new Node();
					node.childNodes[index].ch = chars[i];
				}
				node = node.childNodes[index];
			}
			
			node.isEnd = true;
		}
		
		/** Returns if the word is in the trie. */
		public bool Search(string word) {
			if(string.IsNullOrEmpty(word)) return true;
			
			char[] chars = word.ToCharArray();
			Node node = root;
			for(int i = 0; i < chars.Length; i++){
				int index = chars[i] - 'a';
				if(node.childNodes[index] == null){
					return false;
				}else{
					node = node.childNodes[index];
				}
			}
			return node.isEnd;
		}
		
		/** Returns if there is any word in the trie that starts with the given prefix. */
		public bool StartsWith(string prefix) {
			if(string.IsNullOrEmpty(prefix)) return true;
			
			char[] chars = prefix.ToCharArray();
			Node node = root;
			for(int i = 0; i < chars.Length; i++){
				int index = chars[i] - 'a';
				if(node.childNodes[index] == null){
					return false;
				}else{
					node = node.childNodes[index];
				}
			}
			return true;
		}
	}
}
