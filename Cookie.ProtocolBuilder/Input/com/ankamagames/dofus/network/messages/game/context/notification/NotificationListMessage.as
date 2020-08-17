package com.ankamagames.dofus.network.messages.game.context.notification
{
   import com.ankamagames.jerakine.network.CustomDataWrapper;
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkMessage;
   import com.ankamagames.jerakine.network.NetworkMessage;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   import flash.utils.ByteArray;
   
   [Trusted]
   public class NotificationListMessage extends NetworkMessage implements INetworkMessage
   {
      
      public static const protocolId:uint = 6087;
       
      
      private var _isInitialized:Boolean = false;
      
      public var flags:Vector.<int>;
      
      private var _flagstree:FuncTree;
      
      public function NotificationListMessage()
      {
         this.flags = new Vector.<int>();
         super();
      }
      
      override public function get isInitialized() : Boolean
      {
         return this._isInitialized;
      }
      
      override public function getMessageId() : uint
      {
         return 6087;
      }
      
      public function initNotificationListMessage(param1:Vector.<int> = null) : NotificationListMessage
      {
         this.flags = param1;
         this._isInitialized = true;
         return this;
      }
      
      override public function reset() : void
      {
         this.flags = new Vector.<int>();
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
         this.serializeAs_NotificationListMessage(param1);
      }
      
      public function serializeAs_NotificationListMessage(param1:ICustomDataOutput) : void
      {
         param1.writeShort(this.flags.length);
         var _loc2_:uint = 0;
         while(_loc2_ < this.flags.length)
         {
            param1.writeVarInt(this.flags[_loc2_]);
            _loc2_++;
         }
      }
      
      public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_NotificationListMessage(param1);
      }
      
      public function deserializeAs_NotificationListMessage(param1:ICustomDataInput) : void
      {
         var _loc4_:int = 0;
         var _loc2_:uint = param1.readUnsignedShort();
         var _loc3_:uint = 0;
         while(_loc3_ < _loc2_)
         {
            _loc4_ = param1.readVarInt();
            this.flags.push(_loc4_);
            _loc3_++;
         }
      }
      
      public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_NotificationListMessage(param1);
      }
      
      public function deserializeAsyncAs_NotificationListMessage(param1:FuncTree) : void
      {
         this._flagstree = param1.addChild(this._flagstreeFunc);
      }
      
      private function _flagstreeFunc(param1:ICustomDataInput) : void
      {
         var _loc2_:uint = param1.readUnsignedShort();
         var _loc3_:uint = 0;
         while(_loc3_ < _loc2_)
         {
            this._flagstree.addChild(this._flagsFunc);
            _loc3_++;
         }
      }
      
      private function _flagsFunc(param1:ICustomDataInput) : void
      {
         var _loc2_:int = param1.readVarInt();
         this.flags.push(_loc2_);
      }
   }
}
