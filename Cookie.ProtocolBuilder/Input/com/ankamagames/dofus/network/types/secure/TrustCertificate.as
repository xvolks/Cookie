package com.ankamagames.dofus.network.types.secure
{
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkType;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   
   [Trusted]
   public class TrustCertificate implements INetworkType
   {
      
      public static const protocolId:uint = 377;
       
      
      public var id:uint = 0;
      
      public var hash:String = "";
      
      public function TrustCertificate()
      {
         super();
      }
      
      public function getTypeId() : uint
      {
         return 377;
      }
      
      public function initTrustCertificate(param1:uint = 0, param2:String = "") : TrustCertificate
      {
         this.id = param1;
         this.hash = param2;
         return this;
      }
      
      public function reset() : void
      {
         this.id = 0;
         this.hash = "";
      }
      
      public function serialize(param1:ICustomDataOutput) : void
      {
         this.serializeAs_TrustCertificate(param1);
      }
      
      public function serializeAs_TrustCertificate(param1:ICustomDataOutput) : void
      {
         if(this.id < 0)
         {
            throw new Error("Forbidden value (" + this.id + ") on element id.");
         }
         param1.writeInt(this.id);
         param1.writeUTF(this.hash);
      }
      
      public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_TrustCertificate(param1);
      }
      
      public function deserializeAs_TrustCertificate(param1:ICustomDataInput) : void
      {
         this._idFunc(param1);
         this._hashFunc(param1);
      }
      
      public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_TrustCertificate(param1);
      }
      
      public function deserializeAsyncAs_TrustCertificate(param1:FuncTree) : void
      {
         param1.addChild(this._idFunc);
         param1.addChild(this._hashFunc);
      }
      
      private function _idFunc(param1:ICustomDataInput) : void
      {
         this.id = param1.readInt();
         if(this.id < 0)
         {
            throw new Error("Forbidden value (" + this.id + ") on element of TrustCertificate.id.");
         }
      }
      
      private function _hashFunc(param1:ICustomDataInput) : void
      {
         this.hash = param1.readUTF();
      }
   }
}
