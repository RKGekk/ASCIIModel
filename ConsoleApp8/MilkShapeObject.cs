using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadMS3D {
    public class MilkShapeObject {

        public List<Vertex> arrVertices = new List<Vertex>();
        public List<Triangle> arrTriangles = new List<Triangle>();
        public List<Edge> arrEdges = new List<Edge>();
        public List<Group> arrGroups = new List<Group>();
        public List<Material> arrMaterials = new List<Material>();
        public float fAnimationFPS;
        public float fCurrentTime;
        public int iTotalFrames;
        public List<Joint> arrJoints = new List<Joint>();

        public MilkShapeObject() {
            fAnimationFPS = 24.0f;
            fCurrentTime = 0.0f;
            iTotalFrames = 0;
        }

        public bool LoadFromFile(string fileName) {

            using (BinaryReader reader = new BinaryReader(File.Open(fileName, FileMode.Open))) {

                Header header = new Header();
                byte[] headerIdBuffer = new byte[10];
                reader.Read(headerIdBuffer, 0, 10);
                header.id = System.Text.Encoding.ASCII.GetString(headerIdBuffer);

                byte[] headerVersionBuffer = new byte[4];
                reader.Read(headerVersionBuffer, 0, 4);
                header.version = BitConverter.ToInt32(headerVersionBuffer, 0);

                byte[] vertexCountBuffer = new byte[2];
                reader.Read(vertexCountBuffer, 0, 2);
                short vertexCount = BitConverter.ToInt16(vertexCountBuffer, 0);

                for(short i = 0; i < vertexCount; ++i) {

                    Vertex tempVertex = new Vertex();

                    byte[] vertexFlagsBuffer = new byte[1];
                    reader.Read(vertexFlagsBuffer, 0, 1);
                    tempVertex.flags = vertexFlagsBuffer[0];

                    tempVertex.vertex = new float[3];

                    byte[] vertexVertex1Buffer = new byte[4];
                    reader.Read(vertexVertex1Buffer, 0, 4);
                    tempVertex.vertex[0] = BitConverter.ToSingle(vertexVertex1Buffer, 0);

                    byte[] vertexVertex2Buffer = new byte[4];
                    reader.Read(vertexVertex2Buffer, 0, 4);
                    tempVertex.vertex[1] = BitConverter.ToSingle(vertexVertex2Buffer, 0);

                    byte[] vertexVertex3Buffer = new byte[4];
                    reader.Read(vertexVertex3Buffer, 0, 4);
                    tempVertex.vertex[2] = BitConverter.ToSingle(vertexVertex3Buffer, 0);


                    byte[] vertexBoneIdBuffer = new byte[1];
                    reader.Read(vertexBoneIdBuffer, 0, 1);
                    tempVertex.boneId = vertexBoneIdBuffer[0];
                    
                    byte[] vertexReferenceCountBuffer = new byte[1];
                    reader.Read(vertexReferenceCountBuffer, 0, 1);
                    tempVertex.referenceCount = vertexReferenceCountBuffer[0];

                    this.arrVertices.Add(tempVertex);
                }

                byte[] triangleCountBuffer = new byte[2];
                reader.Read(triangleCountBuffer, 0, 2);
                short nNumTriangles = BitConverter.ToInt16(triangleCountBuffer, 0);
                
                for(short i = 0; i < nNumTriangles; ++i) {

                    Triangle tempTriangle = new Triangle();

                    byte[] triangleFlagsBuffer = new byte[2];
                    reader.Read(triangleFlagsBuffer, 0, 2);
                    tempTriangle.flags = BitConverter.ToInt16(triangleFlagsBuffer, 0);

                    tempTriangle.vertexIndices = new short[3];
                    
                    byte[] triangleIndices1Buffer = new byte[2];
                    reader.Read(triangleIndices1Buffer, 0, 2);
                    tempTriangle.vertexIndices[0] = BitConverter.ToInt16(triangleIndices1Buffer, 0);

                    byte[] triangleIndices2Buffer = new byte[2];
                    reader.Read(triangleIndices2Buffer, 0, 2);
                    tempTriangle.vertexIndices[1] = BitConverter.ToInt16(triangleIndices2Buffer, 0);

                    byte[] triangleIndices3Buffer = new byte[2];
                    reader.Read(triangleIndices3Buffer, 0, 2);
                    tempTriangle.vertexIndices[2] = BitConverter.ToInt16(triangleIndices3Buffer, 0);

                    tempTriangle.vertexNormals = new float[3,3];

                    byte[] triangleNormals1Buffer = new byte[4];
                    reader.Read(triangleNormals1Buffer, 0, 4);
                    tempTriangle.vertexNormals[0, 0] = BitConverter.ToSingle(triangleNormals1Buffer, 0);

                    byte[] triangleNormals2Buffer = new byte[4];
                    reader.Read(triangleNormals2Buffer, 0, 4);
                    tempTriangle.vertexNormals[0, 1] = BitConverter.ToSingle(triangleNormals2Buffer, 0);

                    byte[] triangleNormals3Buffer = new byte[4];
                    reader.Read(triangleNormals3Buffer, 0, 4);
                    tempTriangle.vertexNormals[0, 2] = BitConverter.ToSingle(triangleNormals3Buffer, 0);

                    byte[] triangleNormals4Buffer = new byte[4];
                    reader.Read(triangleNormals4Buffer, 0, 4);
                    tempTriangle.vertexNormals[1, 0] = BitConverter.ToSingle(triangleNormals4Buffer, 0);

                    byte[] triangleNormals5Buffer = new byte[4];
                    reader.Read(triangleNormals5Buffer, 0, 4);
                    tempTriangle.vertexNormals[1, 1] = BitConverter.ToSingle(triangleNormals5Buffer, 0);

                    byte[] triangleNormals6Buffer = new byte[4];
                    reader.Read(triangleNormals6Buffer, 0, 4);
                    tempTriangle.vertexNormals[1, 2] = BitConverter.ToSingle(triangleNormals6Buffer, 0);

                    byte[] triangleNormals7Buffer = new byte[4];
                    reader.Read(triangleNormals7Buffer, 0, 4);
                    tempTriangle.vertexNormals[2, 0] = BitConverter.ToSingle(triangleNormals7Buffer, 0);

                    byte[] triangleNormals8Buffer = new byte[4];
                    reader.Read(triangleNormals8Buffer, 0, 4);
                    tempTriangle.vertexNormals[2, 1] = BitConverter.ToSingle(triangleNormals8Buffer, 0);

                    byte[] triangleNormals9Buffer = new byte[4];
                    reader.Read(triangleNormals9Buffer, 0, 4);
                    tempTriangle.vertexNormals[2, 2] = BitConverter.ToSingle(triangleNormals9Buffer, 0);

                    tempTriangle.s = new float[3];

                    byte[] triangleS1Buffer = new byte[4];
                    reader.Read(triangleS1Buffer, 0, 4);
                    tempTriangle.s[0] = BitConverter.ToSingle(triangleS1Buffer, 0);

                    byte[] triangleS2Buffer = new byte[4];
                    reader.Read(triangleS2Buffer, 0, 4);
                    tempTriangle.s[1] = BitConverter.ToSingle(triangleS2Buffer, 0);

                    byte[] triangleS3Buffer = new byte[4];
                    reader.Read(triangleS3Buffer, 0, 4);
                    tempTriangle.s[2] = BitConverter.ToSingle(triangleS3Buffer, 0);

                    tempTriangle.t = new float[3];

                    byte[] triangleT1Buffer = new byte[4];
                    reader.Read(triangleT1Buffer, 0, 4);
                    tempTriangle.t[0] = BitConverter.ToSingle(triangleT1Buffer, 0);

                    byte[] triangleT2Buffer = new byte[4];
                    reader.Read(triangleT2Buffer, 0, 4);
                    tempTriangle.t[1] = BitConverter.ToSingle(triangleT2Buffer, 0);

                    byte[] triangleT3Buffer = new byte[4];
                    reader.Read(triangleT3Buffer, 0, 4);
                    tempTriangle.t[2] = BitConverter.ToSingle(triangleT3Buffer, 0);

                    byte[] triangleSmoothingGroupBuffer = new byte[1];
                    reader.Read(triangleSmoothingGroupBuffer, 0, 1);
                    tempTriangle.smoothingGroup = triangleSmoothingGroupBuffer[0];
                    
                    byte[] triangleGroupIndexGroupBuffer = new byte[1];
                    reader.Read(triangleGroupIndexGroupBuffer, 0, 1);
                    tempTriangle.groupIndex = triangleGroupIndexGroupBuffer[0];

                    this.arrTriangles.Add(tempTriangle);
                }
            }

            return true;
        }

        public void Clear() {

        }

        public int GetNumVertices() {
            return 0;
        }

        public Vertex GetVertexAt(int nIndex) {
            return new Vertex();
        }

        public int GetNumTriangles() {
            return 0;
        }

        public Triangle GetTriangleAt(int nIndex) {
            return new Triangle();
        }

        int GetNumEdges() {
            return 0;
        }

        public Edge GetEdgeAt(int nIndex) {
            return new Edge();
        }

        public int GetNumGroups() {
            return 0;
        }

        public Group GetGroupAt(int nIndex) {
            return new Group();
        }

        public int GetNumMaterials() {
            return 0;
        }

        public Material GetMaterialAt(int nIndex) {
            return new Material();
        }

        public int GetNumJoints() {
            return 0;
        }

        public Joint GetJointAt(int nIndex) {
            return new Joint();
        }

        public int FindJointByName(string name) {
            return 0;
        }

        public float GetAnimationFPS() {
            return 0.0f;
        }

        public float GetCurrentTime() {
            return 0.0f;
        }

        public int GetTotalFrames() {
            return 0;
        }
    }
}
