package com.ankamagames.dofus.network.messages.game.context.roleplay.emote
{
   import com.ankamagames.jerakine.network.CustomDataWrapper;
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkMessage;
   import com.ankamagames.jerakine.network.NetworkMessage;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   import flash.utils.ByteArray;
   
   [Trusted]
   public class EmoteListMessage extends NetworkMessage implements INetworkMessage
   {
      
      public static const protocolId:uint = 5689;
       
      
      private var _isInitialized:Boolean = false;
      
      public var emoteIds:Vector.<uint>;
      
      private var _emoteIdstree:FuncTree;
      
      public function EmoteListMessage()
      {
         this.emoteIds = new Vector.<uint>();
         super();
      }
      
      override public function get isInitialized() : Boolean
      {
         return this._isInitialized;
      }
      
      override public function getMessageId() : uint
      {
         return 5689;
      }
      
      public function initEmoteListMessage(param1:Vector.<uint> = null) : EmoteListMessage
      {
         this.emoteIds = param1;
         this._isInitialized = true;
         return this;
      }
      
      override public function reset() : void
      {
         this.emoteIds = new Vector.<uint>();
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
         this.serializeAs_EmoteListMessage(param1);
      }
      
      public function serializeAs_EmoteListMessage(param1:ICustomDataOutput) : void
      {
         param1.writeShort(this.emoteIds.length);
         var _loc2_:uint = 0;
         while(_loc2_ < this.emoteIds.length)
         {
            if(this.emoteIds[_loc2_] < 0 || this.emoteIds[_loc2_] > 255)
            {
               throw new Error("Forbidden value (" + this.emoteIds[_loc2_] + ") on element 1 (starting at 1) of emoteIds.");
            }
            param1.writeByte(this.emoteIds[_loc2_]);
            _loc2_++;
         }
      }
      
      public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_EmoteListMessage(param1);
      }
      
      public function deserializeAs_EmoteListMessage(param1:ICustomDataInput) : void
      {
         var _loc4_:uint = 0;
         var _loc2_:uint = param1.readUnsignedShort();
         var _loc3_:uint = 0;
         while(_loc3_ < _loc2_)
         {
            _loc4_ = param1.readUnsignedByte();
            if(_loc4_ < 0 || _loc4_ > 255)
            {
               throw new Error("Forbidden value (" + _loc4_ + ") on elements of emoteIds.");
            }
            this.emoteIds.push(_loc4_);
            _loc3_++;
         }
      }
      
      public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_EmoteListMessage(param1);
      }
      
      public function deserializeAsyncAs_EmoteListMessage(param1:FuncTree) : void
      {
         this._emoteIdstree = param1.addChild(this._emoteIdstreeFunc);
      }
      
      private function _emoteIdstreeFunc(param1:ICustomDataInput) : void
      {
         var _loc2_:uint = param1.readUnsignedShort();
         var _loc3_:uint = 0;
         while(_loc3_ < _loc2_)
         {
            this._emoteIdstree.addChild(this._emoteIdsFunc);
            _loc3_++;
         }
      }
      
      private function _emoteIdsFunc(param1:ICustomDataInput) : void
      {
         var _loc2_:uint = param1.readUnsignedByte();
         if(_loc2_ < 0 || _loc2_ > 255)
         {
            throw new Error("Forbidden value (" + _loc2_ + ") on elements of emoteIds.");
         }
         this.emoteIds.push(_loc2_);
      }
   }
}
