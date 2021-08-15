using System;

namespace DataStructures_Algorithms {

public class MainProgram{
    public static void Main(string[] args) {
        var list = new LinkedList<int>();
        list.Add(1);
        list.Add(2);
        list.Add(3);
        list.Add(5);
        list.Add(6);
        list.Insert(4,3);
        list.Insert(0,0);
        list.Add(7);
        Console.WriteLine(list.ToString());
        list.Remove(0);
        list.Remove(5);
        Console.WriteLine(list.ToString());
        
        var node = list.Search(2);
        Console.WriteLine($"Next Node data is {node.NextNode.Data}");
    }
}

public class LinkedList<T> {
    public Node<T> Head {get; set;}
    public Node<T> Tail {get; set;}
    public bool IsEmpty {
        get {
            return Head != null ?  true : false;
        }
    }

    public int Length {
        get {
            int count = 0;
            Node<T> current = Head;
            while(current != null) {
                count += 1;
                current = current.NextNode;
            }
            return count;
        }
    }

    public void Add(T data) {
        //constaint time to append or prepend to the list
        if(Head == null) {
            Head = new Node<T> { Data = data, NextNode = Head };
            Tail = Head;
        } else {
            Tail.NextNode = new Node<T> { Data = data };
            Tail = Tail.NextNode;
        }
    }

    public void Insert(T Data, int index) {
        // Inserting operation is constant time operation 
        // Searching the index take linear time so overall inerstion time is linear time 
        
        if(index > Length - 1) 
            throw new IndexOutOfRangeException();

        var newnode = new Node<T>() {Data = Data};
        
        //if appending at inde 0 or start on the list
        if(index == 0) {
            newnode.NextNode = Head;
            Head = newnode;
            return;
        }
        
        Node<T> current = Head;
        int count = 0;
        while(count < index - 1) {
            current = current.NextNode;
            count++;
        }

        var temp_ref = current.NextNode;
        current.NextNode = newnode;
        newnode.NextNode = temp_ref;
    }
    public void Remove(T key) {
        Node<T> current = Head;
        Node<T> previous = null;
        bool found = false;

        while(current != null && !found) {
            if(current.Data.Equals(key) && current == Head){
                found = true;
                Head = current.NextNode;
            }
            else if(current.Data.Equals(key)) {
                found = true;
                previous.NextNode = current.NextNode;
            } 
            else {
                previous = current;
                current = current.NextNode;
            }
        }
    }
    public Node<T> Search(T key) {
        Node<T> current = Head;
        while(current != null) {
            if(current.Data.Equals(key)) {
                return current;
            } 
            current = current.NextNode;
        }
        return null;
    }

    public override string ToString() {
        // linear time to print the list
        string print = string.Empty;
        Node<T> current  = Head;

        while(current != null) {
            if(current == Head)
                print += $"[Head: {current.Data}] ";
            else if(current.NextNode == null)
                print += $"--> [Tail: {current.Data}] ";
            else 
                print += $"--> [Node: {current.Data}] ";
            
            current = current.NextNode;
        }

        return print;
    }
}

public class Node<T> {
    public T Data {get; set;}
    public Node<T> NextNode {get; set;}
}

}