package com.ankamagames.dofus.network.types.game.paddock
{
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkType;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   
   public class MountInformationsForPaddock implements INetworkType
   {
      
      public static const protocolId:uint = 184;
       
      
      public var modelId:uint = 0;
      
      public var name:String = "";
      
      public var ownerName:String = "";
      
      public function MountInformationsForPaddock()
      {
         super();
      }
      
      public function getTypeId() : uint
      {
         return 184;
      }
      
      public function initMountInformationsForPaddock(param1:uint = 0, param2:String = "", param3:String = "") : MountInformationsForPaddock
      {
         this.modelId = param1;
         this.name = param2;
         this.ownerName = param3;
         return this;
      }
      
      public function reset() : void
      {
         this.modelId = 0;
         this.name = "";
         this.ownerName = "";
      }
      
      public function serialize(param1:ICustomDataOutput) : void
      {
         this.serializeAs_MountInformationsForPaddock(param1);
      }
      
      public function serializeAs_MountInformationsForPaddock(param1:ICustomDataOutput) : void
      {
         if(this.modelId < 0)
         {
            throw new Error("Forbidden value (" + this.modelId + ") on element modelId.");
         }
         param1.writeVarShort(this.modelId);
         param1.writeUTF(this.name);
         param1.writeUTF(this.ownerName);
      }
      
      public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_MountInformationsForPaddock(param1);
      }
      
      public function deserializeAs_MountInformationsForPaddock(param1:ICustomDataInput) : void
      {
         this._modelIdFunc(param1);
         this._nameFunc(param1);
         this._ownerNameFunc(param1);
      }
      
      public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_MountInformationsForPaddock(param1);
      }
      
      public function deserializeAsyncAs_MountInformationsForPaddock(param1:FuncTree) : void
      {
         param1.addChild(this._modelIdFunc);
         param1.addChild(this._nameFunc);
         param1.addChild(this._ownerNameFunc);
      }
      
      private function _modelIdFunc(param1:ICustomDataInput) : void
      {
         this.modelId = param1.readVarUhShort();
         if(this.modelId < 0)
         {
            throw new Error("Forbidden value (" + this.modelId + ") on element of MountInformationsForPaddock.modelId.");
         }
      }
      
      private function _nameFunc(param1:ICustomDataInput) : void
      {
         this.name = param1.readUTF();
      }
      
      private function _ownerNameFunc(param1:ICustomDataInput) : void
      {
         this.ownerName = param1.readUTF();
      }
   }
}
