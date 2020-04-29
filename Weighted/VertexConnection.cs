using System;

namespace GRAPHics.Weighted
{
    struct VertexConnection<TVertex> : IComparable<VertexConnection<TVertex>>
    {
        public TVertex Origin;
        public TVertex Destination;
        public int Weight;

        public VertexConnection(TVertex origin, TVertex destination) : this()
        {
            this.Origin = origin;
            this.Destination = destination;
        }

        public VertexConnection(TVertex origin, TVertex destination, int weight)
        {
            this.Origin = origin;
            this.Destination = destination;
            this.Weight = weight;
        }

        public int CompareTo([System.Diagnostics.CodeAnalysis.AllowNull] VertexConnection<TVertex> other)
        {
            if (other.Origin.Equals(this.Origin) && other.Destination.Equals(this.Destination))
                return 1;
            return 0;
        }

        public override bool Equals(object obj)
            => (obj as VertexConnection<TVertex>?).HasValue &&
                (obj as VertexConnection<TVertex>?).Value.Origin.Equals(this.Origin) && 
                (obj as VertexConnection<TVertex>?).Value.Destination.Equals(this.Destination);

        public override int GetHashCode()
        {
            return HashCode.Combine(Origin, Destination, Weight);
        }

        public override string ToString()
            => $"{Origin} -> ({Weight}) -> {Destination}";
    }
    
    struct VertexConnection<TVertex, TConnection>
    {
        public TVertex Origin;
        public TVertex Destination;
        public TConnection Weight;

        public VertexConnection(TVertex origin, TVertex destination, TConnection weight)
        {
            this.Origin = origin;
            this.Destination = destination;
            this.Weight = weight;
        }
    }

}
