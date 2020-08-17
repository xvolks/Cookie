package com.ankamagames.dofus.network.types.game.context.roleplay
{
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkType;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   
   [Trusted]
   public class ObjectItemInRolePlay implements INetworkType
   {
      
      public static const protocolId:uint = 198;
       
      
      public var cellId:uint = 0;
      
      public var objectGID:uint = 0;
      
      public function ObjectItemInRolePlay()
      {
         super();
      }
      
      public function getTypeId() : uint
      {
         return 198;
      }
      
      public function initObjectItemInRolePlay(param1:uint = 0, param2:uint = 0) : ObjectItemInRolePlay
      {
         this.cellId = param1;
         this.objectGID = param2;
         return this;
      }
      
      public function reset() : void
      {
         this.cellId = 0;
         this.objectGID = 0;
      }
      
      public function serialize(param1:ICustomDataOutput) : void
      {
         this.serializeAs_ObjectItemInRolePlay(param1);
      }
      
      public function serializeAs_ObjectItemInRolePlay(param1:ICustomDataOutput) : void
      {
         if(this.cellId < 0 || this.cellId > 559)
         {
            throw new Error("Forbidden value (" + this.cellId + ") on element cellId.");
         }
         param1.writeVarShort(this.cellId);
         if(this.objectGID < 0)
         {
            throw new Error("Forbidden value (" + this.objectGID + ") on element objectGID.");
         }
         param1.writeVarShort(this.objectGID);
      }
      
      public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_ObjectItemInRolePlay(param1);
      }
      
      public function deserializeAs_ObjectItemInRolePlay(param1:ICustomDataInput) : void
      {
         this._cellIdFunc(param1);
         this._objectGIDFunc(param1);
      }
      
      public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_ObjectItemInRolePlay(param1);
      }
      
      public function deserializeAsyncAs_ObjectItemInRolePlay(param1:FuncTree) : void
      {
         param1.addChild(this._cellIdFunc);
         param1.addChild(this._objectGIDFunc);
      }
      
      private function _cellIdFunc(param1:ICustomDataInput) : void
      {
         this.cellId = param1.readVarUhShort();
         if(this.cellId < 0 || this.cellId > 559)
         {
            throw new Error("Forbidden value (" + this.cellId + ") on element of ObjectItemInRolePlay.cellId.");
         }
      }
      
      private function _objectGIDFunc(param1:ICustomDataInput) : void
      {
         this.objectGID = param1.readVarUhShort();
         if(this.objectGID < 0)
         {
            throw new Error("Forbidden value (" + this.objectGID + ") on element of ObjectItemInRolePlay.objectGID.");
         }
      }
   }
}
