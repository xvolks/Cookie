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
   public class EntityTalkMessage extends NetworkMessage implements INetworkMessage
   {
      
      public static const protocolId:uint = 6110;
       
      
      private var _isInitialized:Boolean = false;
      
      public var entityId:Number = 0;
      
      public var textId:uint = 0;
      
      public var parameters:Vector.<String>;
      
      private var _parameterstree:FuncTree;
      
      public function EntityTalkMessage()
      {
         this.parameters = new Vector.<String>();
         super();
      }
      
      override public function get isInitialized() : Boolean
      {
         return this._isInitialized;
      }
      
      override public function getMessageId() : uint
      {
         return 6110;
      }
      
      public function initEntityTalkMessage(param1:Number = 0, param2:uint = 0, param3:Vector.<String> = null) : EntityTalkMessage
      {
         this.entityId = param1;
         this.textId = param2;
         this.parameters = param3;
         this._isInitialized = true;
         return this;
      }
      
      override public function reset() : void
      {
         this.entityId = 0;
         this.textId = 0;
         this.parameters = new Vector.<String>();
         this._isInitialized = false;
      }
      
      override public function pack(param1:ICustomDataOutput) : void
      {
         var _loc2_:ByteArray = new ByteArray();
         this.serialize(new CustomDataWrapper(_loc2_));
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
         this.serializeAs_EntityTalkMessage(param1);
      }
      
      public function serializeAs_EntityTalkMessage(param1:ICustomDataOutput) : void
      {
         if(this.entityId < -9007199254740990 || this.entityId > 9007199254740990)
         {
            throw new Error("Forbidden value (" + this.entityId + ") on element entityId.");
         }
         param1.writeDouble(this.entityId);
         if(this.textId < 0)
         {
            throw new Error("Forbidden value (" + this.textId + ") on element textId.");
         }
         param1.writeVarShort(this.textId);
         param1.writeShort(this.parameters.length);
         var _loc2_:uint = 0;
         while(_loc2_ < this.parameters.length)
         {
            param1.writeUTF(this.parameters[_loc2_]);
            _loc2_++;
         }
      }
      
      public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_EntityTalkMessage(param1);
      }
      
      public function deserializeAs_EntityTalkMessage(param1:ICustomDataInput) : void
      {
         var _loc4_:String = null;
         this._entityIdFunc(param1);
         this._textIdFunc(param1);
         var _loc2_:uint = param1.readUnsignedShort();
         var _loc3_:uint = 0;
         while(_loc3_ < _loc2_)
         {
            _loc4_ = param1.readUTF();
            this.parameters.push(_loc4_);
            _loc3_++;
         }
      }
      
      public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_EntityTalkMessage(param1);
      }
      
      public function deserializeAsyncAs_EntityTalkMessage(param1:FuncTree) : void
      {
         param1.addChild(this._entityIdFunc);
         param1.addChild(this._textIdFunc);
         this._parameterstree = param1.addChild(this._parameterstreeFunc);
      }
      
      private function _entityIdFunc(param1:ICustomDataInput) : void
      {
         this.entityId = param1.readDouble();
         if(this.entityId < -9007199254740990 || this.entityId > 9007199254740990)
         {
            throw new Error("Forbidden value (" + this.entityId + ") on element of EntityTalkMessage.entityId.");
         }
      }
      
      private function _textIdFunc(param1:ICustomDataInput) : void
      {
         this.textId = param1.readVarUhShort();
         if(this.textId < 0)
         {
            throw new Error("Forbidden value (" + this.textId + ") on element of EntityTalkMessage.textId.");
         }
      }
      
      private function _parameterstreeFunc(param1:ICustomDataInput) : void
      {
         var _loc2_:uint = param1.readUnsignedShort();
         var _loc3_:uint = 0;
         while(_loc3_ < _loc2_)
         {
            this._parameterstree.addChild(this._parametersFunc);
            _loc3_++;
         }
      }
      
      private function _parametersFunc(param1:ICustomDataInput) : void
      {
         var _loc2_:String = param1.readUTF();
         this.parameters.push(_loc2_);
      }
   }
}
