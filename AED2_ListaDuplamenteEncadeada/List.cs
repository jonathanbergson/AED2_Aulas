﻿using System;

namespace AED2_ListaDuplamenteEncadeada
{
    class List
    {
        private Node sentinel;

        public List()
        {
            sentinel = new Node(-1, null, null);
            sentinel.Previous = sentinel;
            sentinel.Next = sentinel;
        }

        public void Show()
        {
            Console.Write("\n\t[ ");
            for (Node node = sentinel.Next; node != sentinel; node = node.Next)
            {
                Console.Write($"{node.Elem} ");
            }
            Console.Write("]\n");
        }

        public void Prepend(int elem)
        {
            Node node = new Node(elem, sentinel, sentinel.Next);
            node.Previous.Next = node;
            node.Next.Previous = node;
            //node.Next.Previous = node;
            //sentinel.Next = node;
        }

        public void Push(int elem)
        {
            Node node = new Node(elem, sentinel.Previous, sentinel);
            sentinel.Previous.Next = node;
            sentinel.Previous = node;
        }

        public int Shift()
        {
            Node firstNode = sentinel.Next;

            if (firstNode == sentinel)
            {
                throw new Exception("[Exception] A lista está vazia!");
            }

            sentinel.Next = firstNode.Next;
            firstNode.Next.Previous = sentinel;

            return firstNode.Elem;
        }

        public int Pop()
        {
            Node lastNode = sentinel.Previous;

            if (lastNode == sentinel)
            {
                throw new Exception("[Exception] A lista está vazia!");
            }

            sentinel.Previous = lastNode.Previous;
            sentinel.Previous.Next = sentinel;

            return lastNode.Elem;
        }
    }
}
