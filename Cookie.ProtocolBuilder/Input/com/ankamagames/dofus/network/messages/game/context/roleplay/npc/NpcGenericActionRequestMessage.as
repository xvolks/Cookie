package com.ankamagames.dofus.network.messages.game.context.roleplay.npc
{
   import com.ankamagames.jerakine.network.CustomDataWrapper;
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkMessage;
   import com.ankamagames.jerakine.network.NetworkMessage;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   import flash.utils.ByteArray;
   
   [Trusted]
   public class NpcGenericActionRequestMessage extends NetworkMessage implements INetworkMessage
   {
      
      public static const protocolId:uint = 5898;
       
      
      private var _isInitialized:Boolean = false;
      
      public var npcId:int = 0;
      
      public var npcActionId:uint = 0;
      
      public var npcMapId:int = 0;
      
      public function NpcGenericActionRequestMessage()
      {
         super();
      }
      
      override public function get isInitialized() : Boolean
      {
         return this._isInitialized;
      }
      
      override public function getMessageId() : uint
      {
         return 5898;
      }
      
      public function initNpcGenericActionRequestMessage(param1:int = 0, param2:uint = 0, param3:int = 0) : NpcGenericActionRequestMessage
      {
         this.npcId = param1;
         this.npcActionId = param2;
         this.npcMapId = param3;
         this._isInitialized = true;
         return this;
      }
      
      override public function reset() : void
      {
         this.npcId = 0;
         this.npcActionId = 0;
         this.npcMapId = 0;
         this._isInitialized = false;
      }
      
      override public function pack(param1:ICustomDataOutput) : void
      {
         var _loc2_:ByteArray = new ByteArray();
         this.serialize(new CustomDataWrapper(_loc2_));
         if(HASH_FUNCTION != null)
         {
            HASH_FUNCTION(_loc2_);
         }
         writePacket(param1,this.getMessageId(),_loc2_);
      }
      
      override public function unpack(param1:ICustomDataInput, param2:uint) : void
      {
         this.deserialize(param1);
      }
      
      override public function unpackAsync(param1:ICustomDataInput, param2:uint) : FuncTree
      {
         var _loc3_:FuncTree = new FuncTree();
         _loc3_.setRoot(param1);
         this.deserializeAsync(_loc3_);
         return _loc3_;
      }
      
      public function serialize(param1:ICustomDataOutput) : void
      {
         this.serializeAs_NpcGenericActionRequestMessage(param1);
      }
      
      public function serializeAs_NpcGenericActionRequestMessage(param1:ICustomDataOutput) : void
      {
         param1.writeInt(this.npcId);
         if(this.npcActionId < 0)
         {
            throw new Error("Forbidden value (" + this.npcActionId + ") on element npcActionId.");
         }
         param1.writeByte(this.npcActionId);
         param1.writeInt(this.npcMapId);
      }
      
      public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_NpcGenericActionRequestMessage(param1);
      }
      
      public function deserializeAs_NpcGenericActionRequestMessage(param1:ICustomDataInput) : void
      {
         this._npcIdFunc(param1);
         this._npcActionIdFunc(param1);
         this._npcMapIdFunc(param1);
      }
      
      public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_NpcGenericActionRequestMessage(param1);
      }
      
      public function deserializeAsyncAs_NpcGenericActionRequestMessage(param1:FuncTree) : void
      {
         param1.addChild(this._npcIdFunc);
         param1.addChild(this._npcActionIdFunc);
         param1.addChild(this._npcMapIdFunc);
      }
      
      private function _npcIdFunc(param1:ICustomDataInput) : void
      {
         this.npcId = param1.readInt();
      }
      
      private function _npcActionIdFunc(param1:ICustomDataInput) : void
      {
         this.npcActionId = param1.readByte();
         if(this.npcActionId < 0)
         {
            throw new Error("Forbidden value (" + this.npcActionId + ") on element of NpcGenericActionRequestMessage.npcActionId.");
         }
      }
      
      private function _npcMapIdFunc(param1:ICustomDataInput) : void
      {
         this.npcMapId = param1.readInt();
      }
   }
}
