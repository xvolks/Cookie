package com.ankamagames.dofus.network.messages.game.chat
{
   import com.ankamagames.dofus.network.types.game.data.items.ObjectItem;
   import com.ankamagames.jerakine.network.CustomDataWrapper;
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkMessage;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   import flash.utils.ByteArray;
   
   [Trusted]
   public class ChatServerWithObjectMessage extends ChatServerMessage implements INetworkMessage
   {
      
      public static const protocolId:uint = 883;
       
      
      private var _isInitialized:Boolean = false;
      
      public var objects:Vector.<ObjectItem>;
      
      private var _objectstree:FuncTree;
      
      public function ChatServerWithObjectMessage()
      {
         this.objects = new Vector.<ObjectItem>();
         super();
      }
      
      override public function get isInitialized() : Boolean
      {
         return super.isInitialized && this._isInitialized;
      }
      
      override public function getMessageId() : uint
      {
         return 883;
      }
      
      public function initChatServerWithObjectMessage(param1:uint = 0, param2:String = "", param3:uint = 0, param4:String = "", param5:Number = 0, param6:String = "", param7:uint = 0, param8:Vector.<ObjectItem> = null) : ChatServerWithObjectMessage
      {
         super.initChatServerMessage(param1,param2,param3,param4,param5,param6,param7);
         this.objects = param8;
         this._isInitialized = true;
         return this;
      }
      
      override public function reset() : void
      {
         super.reset();
         this.objects = new Vector.<ObjectItem>();
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
      
      override public function serialize(param1:ICustomDataOutput) : void
      {
         this.serializeAs_ChatServerWithObjectMessage(param1);
      }
      
      public function serializeAs_ChatServerWithObjectMessage(param1:ICustomDataOutput) : void
      {
         super.serializeAs_ChatServerMessage(param1);
         param1.writeShort(this.objects.length);
         var _loc2_:uint = 0;
         while(_loc2_ < this.objects.length)
         {
            (this.objects[_loc2_] as ObjectItem).serializeAs_ObjectItem(param1);
            _loc2_++;
         }
      }
      
      override public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_ChatServerWithObjectMessage(param1);
      }
      
      public function deserializeAs_ChatServerWithObjectMessage(param1:ICustomDataInput) : void
      {
         var _loc4_:ObjectItem = null;
         super.deserialize(param1);
         var _loc2_:uint = param1.readUnsignedShort();
         var _loc3_:uint = 0;
         while(_loc3_ < _loc2_)
         {
            _loc4_ = new ObjectItem();
            _loc4_.deserialize(param1);
            this.objects.push(_loc4_);
            _loc3_++;
         }
      }
      
      override public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_ChatServerWithObjectMessage(param1);
      }
      
      public function deserializeAsyncAs_ChatServerWithObjectMessage(param1:FuncTree) : void
      {
         super.deserializeAsync(param1);
         this._objectstree = param1.addChild(this._objectstreeFunc);
      }
      
      private function _objectstreeFunc(param1:ICustomDataInput) : void
      {
         var _loc2_:uint = param1.readUnsignedShort();
         var _loc3_:uint = 0;
         while(_loc3_ < _loc2_)
         {
            this._objectstree.addChild(this._objectsFunc);
            _loc3_++;
         }
      }
      
      private function _objectsFunc(param1:ICustomDataInput) : void
      {
         var _loc2_:ObjectItem = new ObjectItem();
         _loc2_.deserialize(param1);
         this.objects.push(_loc2_);
      }
   }
}
